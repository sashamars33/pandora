using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 2f;
    public float playerChaseRadius = 8f;       // How close the player must be to wake the enemy
    public float torchAttractionRadius = 6f;    // How close the torch must be for the enemy to care
    public float obstacleCheckDistance = 1f;
    public Rigidbody2D rb;

    private Transform player;
    private UnityEngine.Vector2 movementDirection;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Transform target = GetTarget();
        if (target != null)
        {
            MoveToward(target.position);
        }
        else
        {
            rb.velocity = UnityEngine.Vector2.zero;
        }
    }

    Transform GetTarget()
    {
        // 1️⃣ Check if player is within wake radius
        float playerDistance = UnityEngine.Vector2.Distance(transform.position, player.position);
        bool playerIsClose = playerDistance <= playerChaseRadius;

        // 2️⃣ Find the nearest *lit torch* within torchAttractionRadius
        Torch[] torches = FindObjectsOfType<Torch>();
        Torch nearbyLitTorch = torches
            .Where(t => t.illuminated && UnityEngine.Vector2.Distance(transform.position, t.transform.position) <= torchAttractionRadius)
            .OrderBy(t => UnityEngine.Vector2.Distance(transform.position, t.transform.position))
            .FirstOrDefault();

        // 3️⃣ Prioritize lit torch if one is nearby; else chase player if awake
        if (nearbyLitTorch != null)
            return nearbyLitTorch.transform;

        if (playerIsClose)
            return player;

        return null; // Stay idle
    }

    void MoveToward(UnityEngine.Vector2 targetPos)
    {
        // Calculate movement direction
        movementDirection = (targetPos - (UnityEngine.Vector2)transform.position).normalized;

        // Check for obstacles using a raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, obstacleCheckDistance, LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            // Simple obstacle avoidance: slide slightly sideways
            UnityEngine.Vector2 perp = UnityEngine.Vector2.Perpendicular(movementDirection);
            movementDirection += perp * 0.5f;
            movementDirection.Normalize();
        }

        // Move using Rigidbody2D
        UnityEngine.Vector2 newPos = (UnityEngine.Vector2)transform.position + movementDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

  
}

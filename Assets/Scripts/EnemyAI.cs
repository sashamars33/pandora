using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
       [Header("Enemy Settings")]
    public float speed = 2f;
    private Transform player;
    public Rigidbody2D rb;

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
    }

    Transform GetTarget()
    {
        // Find all torches in the scene
        Torch[] torches = FindObjectsOfType<Torch>();

        // Find the nearest *lit* torch
        Torch litTorch = torches
            .Where(t => t.illuminated)
            .OrderBy(t => Vector2.Distance(transform.position, t.transform.position))
            .FirstOrDefault();

        if (litTorch != null)
        {
            return litTorch.transform; // Go toward the lit torch
        }
        else
        {
            return player; // No lit torches → chase the player
        }
    }

    void MoveToward(Vector2 targetPos)
    {
        Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
        Vector2 newPos = (Vector2)transform.position + direction * speed * Time.fixedDeltaTime;

        // Move using Rigidbody2D for physics interaction
        rb.MovePosition(newPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private float horizontalMovement;
    private float verticalMovement;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
    }

    
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<UnityEngine.Vector2>();
        horizontalMovement = move.x;
        verticalMovement = move.y;
    }
}

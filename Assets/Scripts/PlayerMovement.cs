using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    [Header("Floatiness Settings")]
    [Tooltip("How quickly the player accelerates toward input velocity.")]
    [Range(0.1f, 20f)] public float acceleration = 5f;

    [Tooltip("How quickly the player slows down when not moving.")]
    [Range(0f, 1f)] public float drag = 0.1f;

    [Tooltip("Extra upward force to simulate reduced gravity or buoyancy.")]
    public float floatForce = 0.0f;

    [Tooltip("Optional vertical oscillation amplitude (makes it bob slightly).")]
    public float bobAmplitude = 0f;

    [Tooltip("Speed of the vertical bobbing motion.")]
    public float bobFrequency = 1f;

    [Header("Rotation")]
    [Tooltip("How quickly the sprite rotates to face its movement direction.")]
    [Range(0.1f, 20f)] public float rotationSpeed = 10f;

    [Tooltip("If true, the sprite will flip only left/right instead of rotating freely (for side-view games).")]
    public bool flipXOnly = false;

    private Vector2 moveInput;
    private Vector2 currentVelocity;

    void Update()
    {
        // --- FLOATY MOVEMENT ---
        Vector2 targetVelocity = moveInput * moveSpeed;

        // Smoothly interpolate toward target velocity
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);

        // Apply drag when no input
        if (moveInput.magnitude < 0.1f)
            currentVelocity *= (1f - drag);

        // Vertical bobbing
        float bobOffset = 0f;
        if (bobAmplitude > 0f)
            bobOffset = Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;

        // Apply velocity + float force
        rb.velocity = new Vector2(currentVelocity.x, currentVelocity.y + floatForce + bobOffset);

        // --- ROTATION / FACING ---
        FaceMovementDirection();
    }

    void FaceMovementDirection()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.sqrMagnitude > 0.001f)
        {
            if (flipXOnly)
            {
                // Simple left/right flip
                if (velocity.x > 0.05f)
                    transform.localScale = new Vector3(1, 1, 1);
                else if (velocity.x < -0.05f)
                    transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                // Smoothly rotate to face movement direction
                float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}

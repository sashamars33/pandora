using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDebugger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} is still colliding with {collision.gameObject.name}");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} stopped colliding with {collision.gameObject.name}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} entered trigger with {other.gameObject.name}");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} exited trigger with {other.gameObject.name}");
    }
}

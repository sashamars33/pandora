using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Torches item = collision.GetComponent<Torches>();
        if(item != null)
        {
            item.illuminate();
        }
    }
}

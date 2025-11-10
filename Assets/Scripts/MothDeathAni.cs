using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothDeathAni : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool mothDeath;

    void Start()
    {
         animator = GetComponent<Animator>();
    }
   void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Trigger with: " + other.gameObject.name);
    if (gameObject.CompareTag("EnemySprite"))
    {
        Debug.Log("Trigger Torch");
        mothDeath = true;
        animator.SetBool("mothDeath", mothDeath);
        Destroy(gameObject, 12f);
    }
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollison : MonoBehaviour
{
    public GameOverScreen gameOverUI;
void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
         if (gameOverUI != null)
        {
            gameOverUI.ShowGameOverScreen();
        } else
        {
            Debug.LogWarning("No GameOverUIManager assigned!");
        }
    }
}

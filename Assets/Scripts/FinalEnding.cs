using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnding : MonoBehaviour
{
        public FinalEndingScreen finalUI;
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Statue"))
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
         if (finalUI != null)
        {
            finalUI.ShowFinalEndingScreen();
        } else
        {
            Debug.LogWarning("No GameOverUIManager assigned!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEndingScreen : MonoBehaviour
{
     public void ShowFinalEndingScreen()
    {
        Debug.Log("Final screen activated!");
        gameObject.SetActive(true);

        // Optionally pause the game
        Time.timeScale = 0f;
    }
}

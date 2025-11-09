using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public string gameSceneName = "MainScene"; // name of your main scene

    public void StartGame()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(gameSceneName);
    }
}

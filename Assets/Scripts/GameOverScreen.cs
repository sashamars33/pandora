using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [Header("Scene Names")]
    public string startSceneName = "StartScene";  // Your main menu or first scene
    public string runSceneName = "MainScene";      // The scene where the player spawns at run start

    public void ShowGameOverScreen()
    {
        Debug.Log("Game Over screen activated!");
        gameObject.SetActive(true);

        // Optionally pause the game
        Time.timeScale = 0f;
    }

    public void HideGameOverScreen()
    {
        Debug.Log("Game Over screen hidden!");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    // Called by the left button (restart run)
    public void RestartRun()
    {
        Debug.Log("Restarting run with saved progress...");
        SceneManager.LoadScene(runSceneName);
        Time.timeScale = 1f;
    }

    // Called by the right button (full restart)
    public void FullRestart()
    {
        Debug.Log("Full restart - clearing all saved progress...");
        PlayerPrefs.DeleteAll(); // Removes all torch save data and other progress
        PlayerPrefs.Save();

        SceneManager.LoadScene(startSceneName);
        Time.timeScale = 1f;
    }
}

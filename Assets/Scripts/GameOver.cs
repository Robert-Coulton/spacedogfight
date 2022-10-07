using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public PlayerSpawner playerSpawner;

    public void Restart()
    {
        playerSpawner.gameOver = false;
        playerSpawner.gameOverCounted = false;
        GameMaster.instance.GameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

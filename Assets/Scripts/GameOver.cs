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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
        //Time.timeScale = 1f;
        //gameOverUI.SetActive(false);
        //gameOverUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

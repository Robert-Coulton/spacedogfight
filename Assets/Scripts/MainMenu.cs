using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsMenuUI;
    public GameObject gameservicesMenuUI;
    public GameObject skinMenuUI;

    public float transitionTime = .5f;
    public Animator transition;

    public void Play()
    {
        StartCoroutine(LoadLevel());
        //AudioManager.instance.Play("StartGame");
        //SceneManager.LoadScene("Main");
    }

    IEnumerator LoadLevel()
    {
        AudioManager.instance.Play("StartGame");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void GameServicesMenu()
    {
        if (gameservicesMenuUI.activeInHierarchy == true)
        {
            gameservicesMenuUI.SetActive(false);
        } else
        {
            gameservicesMenuUI.SetActive(true);
        }
    }

    public void SkinMenu()
    {
        if (skinMenuUI.activeInHierarchy == true)
        {
            skinMenuUI.SetActive(false);
        }
        else
        {
            skinMenuUI.SetActive(true);
            mainMenuUI.SetActive(false);
        }
    }

    public void BackButton()
    {
        FindObjectOfType<AudioManager>().Play("Cancel");
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        skinMenuUI.SetActive(false);
    }
}

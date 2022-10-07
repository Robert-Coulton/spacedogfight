using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public TMP_Text[] scoreText;
    public TMP_Text experienceText;
    public TMP_Text creditText;

    public float score;
    public float experience;

    public SaveScriptableObject SaveScriptableObject;

    public float timeMultiplier;
    public float creditMultiplier;
    public float experienceMultiplier;

    public PlayerSpawner playerSpawner;

    public static GameMaster instance;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 1f;
        instance = this;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerSpawner.gameOver)
        {
            score += timeMultiplier * Time.deltaTime;
            scoreText[0].text = score.ToString("0");
            scoreText[1].text = "   " + score.ToString("0");
        }
        else
        {
            if (!GameOver)
            {
                UpdateCoinsAndExperience();
                GameOver = true;
            }
        }
    }

    public void UpdateCoinsAndExperience()
    {
        experience += score * experienceMultiplier;
        experienceText.text = "+ " + experience.ToString("#") + " Experience";

        SaveScriptableObject.coins += score * creditMultiplier;
        creditText.text = "+ " + SaveScriptableObject.coins.ToString("#") + " Credits";
    }
}

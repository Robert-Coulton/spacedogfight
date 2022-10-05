using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTime : MonoBehaviour
{
    public TMP_Text scoreText;
    private float score;
    public float timeMultiplier;

    // Start is called before the first frame update
    void Start()
    {
      score = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        score += timeMultiplier * Time.deltaTime;
        scoreText.text = score.ToString("0");
    }
}

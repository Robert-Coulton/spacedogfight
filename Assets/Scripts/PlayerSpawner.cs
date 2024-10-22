﻿using UnityEngine;
using System.Collections;
using TMPro;
using Ads;

public class PlayerSpawner : MonoBehaviour {

	public TMP_Text lives;

	public GameObject playerPrefab;
	GameObject playerInstance;

	public GameObject gameOverUI;
	public GameObject scoreUI;

	public int numLives = 4;
	public bool gameOver = false;
	float respawnTimer;

	int restartCount = 0;

	public InterstitialAd ad;
	public bool gameOverCounted = false;

	public EnemySpawner spawner;

	void Start () {
		SpawnPlayer();
	}

	void SpawnPlayer() {
		numLives--;
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}
	
	void Update () {
		lives.text = numLives.ToString("");
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				SpawnPlayer();
			}

			gameOverCounted = false;
        }
	}

	void OnGUI() {
		if(numLives == 0 && playerInstance == null) {
			gameOver = true;
			gameOverUI.SetActive(true);
			scoreUI.SetActive(false);

            if (!gameOverCounted)
            {
				restartCount++;
				gameOverCounted = true;
				SaveManager.instance.Save();
			}

			if (restartCount > 3)
            {
				ad.ShowAd();
				restartCount = 0;
            }

			spawner.ResetTime();
		}
	}

	public void AddLife()
    {
		numLives++;
    }
}

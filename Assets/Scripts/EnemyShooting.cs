﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
	
	public GameObject bulletPrefab;
	int bulletLayer;

	public float fireDelay = 0.50f;
	float cooldownTimer = 0;

	public int fireDistance;

	Transform player;

	public string[] fireAudio;
	private int soundIndex;

	void Start() {
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {

		if(player == null) {
			// Find the player's ship!
			GameObject go = GameObject.FindWithTag ("Player");
			
			if(go != null) {
				player = go.transform;
			}
		}

		soundIndex = Random.Range(0, fireAudio.Length);

		cooldownTimer -= Time.deltaTime;
		
		if( cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < fireDistance) {

			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;

			if(fireAudio.Length != 0)
            {
				AudioManager.instance.Play(fireAudio[soundIndex]);
			}

			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}

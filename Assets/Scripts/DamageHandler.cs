using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	// Health

	public int health = 1;

	// Death Sounds

	public string deathSound;

	// Invulnerablility Frames

	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	// Particle Prefab

	public GameObject deathParticle;

	SpriteRenderer spriteRend;

	// Camera Shake

	public bool hasShake = false;
	public float shakeAmount;

	// Add Score

	public bool addScore = false;
	public float addScoreAmount;

	// Drops

	//public GameObject healthDrop;
	public GameObject[] drops;
	const float dropChance = 2f / 10f;

	void Start() {
		correctLayer = gameObject.layer;

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {

		health--;

		if (invulnPeriod > 0)
		{
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}
	}

	void Update() {

		if(invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;

			if(invulnTimer <= 0) {
				gameObject.layer = correctLayer;
				if(spriteRend != null) {
					spriteRend.enabled = true;
				}
			}
			else {
				if(spriteRend != null) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		if(health <= 0) {
			Die();
		}
	}

	void Die() {
		Vector3 deathPos = this.gameObject.transform.position;
		if(deathParticle != null)
		{
			Instantiate(deathParticle, deathPos, Quaternion.identity); 
		}
		if(deathSound != null)
        {
			AudioManager.instance.Play(deathSound);
		}
		if(hasShake == true)
        {
			CameraShake.Shake(0.25f, shakeAmount);
		}
		if(addScore == true)
        {
			GameMaster.instance.score += addScoreAmount;
        }
		if(Random.Range(0f, 1f) <= dropChance && drops.Length > 0)
        {
			//Instantiate(healthDrop, deathPos, Quaternion.identity);
			Instantiate(drops[Random.Range(0, drops.Length)], deathPos, Quaternion.identity);
		}
		Destroy(gameObject);
	}

}

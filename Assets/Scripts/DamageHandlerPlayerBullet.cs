using UnityEngine;
using System.Collections;

public class DamageHandlerPlayerBullet : MonoBehaviour
{

	public int health = 1;

//	public string targetTag;
	public string deathSound;

	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	public GameObject deathParticle;

	SpriteRenderer spriteRend;

	void Start()
	{
		correctLayer = gameObject.layer;

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer>();

		if (spriteRend == null)
		{
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if (spriteRend == null)
			{
				Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "Enemy")
		{
			health--;
			if (invulnPeriod > 0)
			{
				invulnTimer = invulnPeriod;
				gameObject.layer = 10;
			}
		} 

	}

	void Update()
	{

		if (invulnTimer > 0)
		{
			invulnTimer -= Time.deltaTime;

			if (invulnTimer <= 0)
			{
				gameObject.layer = correctLayer;
				if (spriteRend != null)
				{
					spriteRend.enabled = true;
				}
			}
			else
			{
				if (spriteRend != null)
				{
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Vector3 deathPos = this.gameObject.transform.position;
		if (deathParticle != null)
		{
			Instantiate(deathParticle, deathPos, Quaternion.identity);
		}
		if (deathSound != null)
		{
			AudioManager.instance.Play(deathSound);
		}
		Destroy(gameObject);
	}

}

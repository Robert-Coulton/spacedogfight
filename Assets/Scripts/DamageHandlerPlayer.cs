using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageHandlerPlayer : MonoBehaviour
{
	public int health = 1;
	int maxHealth, minHealth = 0;

	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	public GameObject deathParticle;

	SpriteRenderer spriteRend;

	public GameObject healthBar;
	public PlayerSpawner playerSpawner;

	public bool hasShake = false;
	public float shakeAmount;

	void Start()
	{
		maxHealth = health;
		healthBar = GameObject.FindGameObjectWithTag("HealthBar");
		healthBar.GetComponent<HealthBar>().SetMaxHealth(health);
		healthBar.GetComponent<HealthBar>().currHealth = maxHealth;

		playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawnSpot").GetComponent<PlayerSpawner>();

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

		if (collider.tag == "Enemy" || collider.tag == "EnemyWeapon")
		{
			health--;
			//healthBar.GetComponent<HealthBar>().SetHealth(health);
			healthBar.GetComponent<HealthBar>().currHealth = health;
			if (invulnPeriod > 0)
			{
				invulnTimer = invulnPeriod;
				gameObject.layer = 10;
			}
			if (hasShake == true)
			{
				CameraShake.Shake(0.25f, shakeAmount);
			}
		}

		if(collider.gameObject.GetComponent<Pickup>())
        {
			var pickup = collider.gameObject.GetComponent<Pickup>();

			switch (pickup.type)
            {
				case Pickup.PickupType.health:

					health++;
					healthBar.GetComponent<HealthBar>().currHealth = health;

					break;

				case Pickup.PickupType.tri_shot:

					PlayerShooting.instance.AddTriTime();

					break;

				case Pickup.PickupType.super_shield:

					playerSpawner.AddLife();

					break;

				case Pickup.PickupType.speed_boost:

					GetComponent<PlayerMovementTouch>().AddSpeedBoost();

					break;

				case Pickup.PickupType.invulnerability:

					invulnTimer += 5f;

					break;

				case Pickup.PickupType.rear_gun:

					PlayerShooting.instance.AddReverseTime();

					break;
			}
		}

	}

	void Update()
	{

		if (invulnTimer > 0)
		{
			invulnTimer -= Time.deltaTime;

			GetComponent<PolygonCollider2D>().enabled = false;

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
        else
        {
			GetComponent<PolygonCollider2D>().enabled = true;
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Vector3 deathPos = this.gameObject.transform.position;
		Instantiate(deathParticle, deathPos, Quaternion.identity);
		AudioManager.instance.Play("Explosion");
		//FindObjectOfType<AudioManager>().Play("Explosion");
		Destroy(gameObject);
	}

}

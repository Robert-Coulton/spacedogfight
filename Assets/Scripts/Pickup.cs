using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public string pickupSound;
	public GameObject pickupParticle;

	public PickupType type;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			Die();
		}
	}

	void Die()
	{
		Vector3 deathPos = this.gameObject.transform.position;
		if (pickupParticle != null)
		{
			Instantiate(pickupParticle, deathPos, Quaternion.identity);
		}
		if (pickupSound != "")
		{
			AudioManager.instance.Play(pickupSound);
		}
		Destroy(gameObject);
	}

	public enum PickupType
    {
		health,
		tri_shot,
		super_shield,
		speed_boost,
		invulnerability,
		rear_gun,
    }
}

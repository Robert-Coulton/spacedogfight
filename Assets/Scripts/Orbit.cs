using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{

	public float rotSpeed = 90f;

	Transform orbitPoint;

	// Update is called once per frame
	void Update()
	{
		if (orbitPoint == null)
		{
			// Find the player's ship!
			GameObject go = GameObject.FindWithTag("OrbitPoint");

			if (go != null)
			{
				orbitPoint = go.transform;
			}
		}

		// At this point, we've either found the player,
		// or he/she doesn't exist right now.

		if (orbitPoint == null)
			return; // Try again next frame!

		// HERE -- we know for sure we have a player. Turn to face it!

		Vector3 dir = orbitPoint.position - transform.position;
		dir.Normalize();

		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}

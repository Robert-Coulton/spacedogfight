using UnityEngine;
using System.Collections;

public class PlayerMovementTouch : MonoBehaviour
{

	public float maxSpeed = 5f;
	//public float rotSpeed = 180f;

	public Joystick joystick;

	//float shipBoundaryRadius = 0.5f;

	public float speedBoostTimer = 0f;
	public float defaultSpeed;

	void Start()
	{
		joystick = FindObjectOfType<Joystick>();
		defaultSpeed = maxSpeed;
	}

	void Update()
	{
		//Upgrade Timers

		speedBoostTimer -= Time.deltaTime;

		if(speedBoostTimer <= 0)
        {
			speedBoostTimer = 0;
			RemoveSpeedBoost();
        }


		// ROTATE the ship.

		// Grab our rotation quaternion
		//Quaternion rot = transform.rotation;

		// Grab the Z euler angle
		//float z = rot.eulerAngles.z;

		// Change the Z angle based on input
		//z -= joystick.Horizontal * rotSpeed * Time.deltaTime;

		// Recreate the quaternion
		//rot = Quaternion.Euler(0, 0, z);

		// Feed the quaternion into our rotation
		//transform.rotation = rot;

		float horizontal = joystick.Horizontal * Time.deltaTime * maxSpeed;
		float vertical = joystick.Vertical * Time.deltaTime * maxSpeed;

		float angle = Mathf.Atan2(-horizontal, vertical) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		//Vector2 dir = new Vector2(joystick.Horizontal, joystick.Vertical);
		//transform.LookAt(Vector2.up, (Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg));

		// MOVE the ship.
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(horizontal, vertical, 0);

		pos += velocity;

		// RESTRICT the player to the camera's boundaries!

		// First to vertical, because it's simpler
		//if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
		//{
		//	pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		//}
		//if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
		//{
		//	pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		//}

		// Now calculate the orthographic width based on the screen ratio
		//float screenRatio = (float)Screen.width / (float)Screen.height;
		//float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		//if (pos.x + shipBoundaryRadius > widthOrtho)
		//{
		//	pos.x = widthOrtho - shipBoundaryRadius;
		//}
		//if (pos.x - shipBoundaryRadius < -widthOrtho)
		//{
		//	pos.x = -widthOrtho + shipBoundaryRadius;
		//}

		// Finally, update our position!!
		transform.position = pos;


	}

	public void AddSpeedBoost()
    {
		speedBoostTimer += 5f;

		maxSpeed = defaultSpeed * 1.5f;
    }

	public void RemoveSpeedBoost()
    {
		maxSpeed = defaultSpeed;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public static PlayerShooting instance;

	public Vector3 bulletOffset = new Vector3(0, .75f, 0);

	public GameObject bulletPrefab;
	//public Transform shootLocation;
	int bulletLayer;

	public GameObject player;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	public string[] fireAudio;
	private int soundIndex;

	public float reverseTimer;
	public float triTimer;

	void Start() {
		instance = this;
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");

		soundIndex = Random.Range(0, fireAudio.Length);

		if (Input.GetButton("Fire1") && cooldownTimer <= 0)
		{
			Shoot();
		}

		reverseTimer -= Time.deltaTime;
		triTimer -= Time.deltaTime;

		if (reverseTimer <= 0)
			reverseTimer = 0;

		if (triTimer <= 0)
			triTimer = 0;
	}

	public void OnPointerDown(PointerEventData eventdata)
	{
		InvokeRepeating("Shoot", 0, fireDelay);
	}

	public void OnPointerUp(PointerEventData eventdata)
	{
		CancelInvoke("Shoot");
	}

	public void Shoot()
    {
      
		cooldownTimer = fireDelay;

		Vector3 offset = bulletOffset;

		if(player != null)
			offset = player.transform.rotation * bulletOffset;

		if (fireAudio.Length != 0)
		{
			AudioManager.instance.Play(fireAudio[soundIndex]);
		}

		if(triTimer > 0 && reverseTimer > 0)
        {
			//Left and Right

			GameObject bulletGO = Instantiate(bulletPrefab, player.transform.position + new Vector3(offset.x - .5f, offset.y, offset.z), new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO.layer = bulletLayer;

			GameObject bulletGO2 = Instantiate(bulletPrefab, player.transform.position + new Vector3(offset.x + .5f, offset.y, offset.z), new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO2.layer = bulletLayer;

			// Front and Rear

			GameObject bulletGO3 = Instantiate(bulletPrefab, player.transform.position + offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO3.layer = bulletLayer;

			GameObject bulletGO4 = Instantiate(bulletPrefab, player.transform.position - offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z - 180, player.transform.rotation.w));
			bulletGO4.layer = bulletLayer;
		}
		else if(reverseTimer > 0)
        {
			GameObject bulletGO = Instantiate(bulletPrefab, player.transform.position - offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z - 180, player.transform.rotation.w));
			bulletGO.layer = bulletLayer;

			GameObject bulletGO2 = Instantiate(bulletPrefab, player.transform.position + offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO2.layer = bulletLayer;
		}
        else if(triTimer > 0)
        {
			GameObject bulletGO = Instantiate(bulletPrefab, player.transform.position + new Vector3(offset.x - .6f, offset.y, offset.z), new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO.layer = bulletLayer;

			GameObject bulletGO2 = Instantiate(bulletPrefab, player.transform.position + new Vector3(offset.x + .6f, offset.y, offset.z), new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO2.layer = bulletLayer;

			GameObject bulletGO3 = Instantiate(bulletPrefab, player.transform.position + offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO3.layer = bulletLayer;
		}
        else
        {
			GameObject bulletGO = Instantiate(bulletPrefab, player.transform.position + offset, new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w));
			bulletGO.layer = bulletLayer;
		}

    }

	public void AddReverseTime()
    {
		reverseTimer += 5f;
    }

	public void AddTriTime()
	{
		triTimer += 5f;
	}
}

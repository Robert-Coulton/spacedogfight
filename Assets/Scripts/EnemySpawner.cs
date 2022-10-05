using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public GameObject gm;

	float spawnDistance = 20f;

	public float enemyRate = 5;
	float nextEnemy = 1;

	public int maxEnemies;
	public float time = 0; 
	void Start()
    {
		gm = GameObject.FindGameObjectWithTag("GM");

    }

	public void ResetTime()
    {
		time = 0;
    }

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime / 20f;
		nextEnemy -= Time.deltaTime;

		if(nextEnemy <= 0) {
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if(enemyRate < 3)
				enemyRate = 3;

			Vector3 offset = Random.onUnitSphere;

			offset.z = 0;

			offset = offset.normalized * spawnDistance;

			//Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
			if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
				if (gm.GetComponent<GameMaster>().score >= 300)
				{
					GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], transform.position + offset, Quaternion.identity);
					float startSpeed = enemy.GetComponent<MoveForward>().maxSpeed;
					float nerfedSpeed = startSpeed * .75f;
					float newSpeed = nerfedSpeed + time;

					if (newSpeed > startSpeed)
					{
						newSpeed = startSpeed;
					}

					enemy.GetComponent<MoveForward>().maxSpeed = newSpeed;
				}
				if (gm.GetComponent<GameMaster>().score >= 200)
				{
					GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], transform.position + offset, Quaternion.identity);
					float startSpeed = enemy.GetComponent<MoveForward>().maxSpeed;
					float nerfedSpeed = startSpeed * .75f;
					float newSpeed = nerfedSpeed + time;

					if (newSpeed > startSpeed)
					{
						newSpeed = startSpeed;
					}

					enemy.GetComponent<MoveForward>().maxSpeed = newSpeed;
				}
				else if (gm.GetComponent<GameMaster>().score >= 100)
				{
					GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], transform.position + offset, Quaternion.identity);
					float startSpeed = enemy.GetComponent<MoveForward>().maxSpeed;
					float nerfedSpeed = startSpeed * .75f;
					float newSpeed = nerfedSpeed + time;

					if (newSpeed > startSpeed)
					{
						newSpeed = startSpeed;
					}

					enemy.GetComponent<MoveForward>().maxSpeed = newSpeed;
				}
				else if (gm.GetComponent<GameMaster>().score < 100)
				{
					GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], transform.position + offset, Quaternion.identity);
					float startSpeed = enemy.GetComponent<MoveForward>().maxSpeed;
					float nerfedSpeed = startSpeed * .75f;
					float newSpeed = nerfedSpeed + time;

					if (newSpeed > startSpeed)
					{
						newSpeed = startSpeed;
					}

					enemy.GetComponent<MoveForward>().maxSpeed = newSpeed;
				}
			}
			
		}
	}
}

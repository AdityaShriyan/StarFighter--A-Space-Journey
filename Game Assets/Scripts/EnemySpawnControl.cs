using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour 
{
	public GameObject EnemyPrefab;
	float maxSpawnRate=5f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnEnemy()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.2f;
		min.x = min.x + 0.2f;

		GameObject enemy = (GameObject)Instantiate (EnemyPrefab);
		enemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		ScheduleNext ();
	}

	void ScheduleNext ()
	{
		float spawnTime;
		if (maxSpawnRate > 1f) {
			spawnTime = Random.Range (1f, maxSpawnRate);
		} 
		else 
		{
			spawnTime = 1f;
		}
		Invoke ("SpawnEnemy", spawnTime);
	}

	void IncreaseSpawnRate () 
	{
		if (maxSpawnRate > 1f) 
		{
			maxSpawnRate--;
		}

		if (maxSpawnRate == 1f) 
		{
			CancelInvoke ("IncreaseSpawnRate");
		}
	}

	public void StartEnemySpawning ()
	{

		maxSpawnRate=5f;

		Invoke ("SpawnEnemy",maxSpawnRate);

		InvokeRepeating ("IncreaseSpawnRate", 0f, 15f);
	}

	public void StopEnemySpawning ()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
}

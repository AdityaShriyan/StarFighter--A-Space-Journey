using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour 
{
	public GameObject BulletPrefab;
	float maxFireRate=3f;

	// Use this for initialization
	void Start () 
	{
		Invoke ("FireBullet",0.5f);

		InvokeRepeating ("IncreaseFireRate", 0f, 15f);
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void FireBullet()
	{
		GameObject Bullet = (GameObject)Instantiate (BulletPrefab);
		Bullet.transform.position = transform.position;

		ScheduleNext ();
	}

	void ScheduleNext ()
	{
		float fireTime;
		if (maxFireRate > 1f) {
			fireTime = Random.Range (1f, maxFireRate);
		} 
		else 
		{
			fireTime = 1f;
		}
		Invoke ("FireBullet", fireTime);
	}

	void IncreaseFireRate () 
	{
		if (maxFireRate > 1f) 
		{
			maxFireRate--;
		}

		if (maxFireRate == 1f) 
		{
			CancelInvoke ("IncreaseFireRate");
		}
	}
}

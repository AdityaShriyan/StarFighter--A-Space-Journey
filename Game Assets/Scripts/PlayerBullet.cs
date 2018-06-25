using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour 
{
	float speed;
	// Use this for initialization
	void Start () 
	{
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = transform.position;

		pos = new Vector2 (pos.x, pos.y + speed * Time.deltaTime);

		transform.position = pos;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (transform.position.y > max.y) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "EnemyShipTag") 
		{
			Destroy (gameObject);
		}
	}
}

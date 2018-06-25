using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	float speed;
	// Use this for initialization
	void Start () 
	{
		speed = 5f;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = transform.position;

		pos = new Vector2 (pos.x, pos.y - speed * Time.deltaTime);

		transform.position = pos;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.y < min.y) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "PlayerShipTag") 
		{
			Destroy (gameObject);
		}
	}
}

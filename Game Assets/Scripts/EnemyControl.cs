using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour 
{
	GameObject ScoreTextUI;
	float speed;
	public GameObject ExplosionPrefab;
	// Use this for initialization
	void Start () 
	{
		speed = 2f;
		ScoreTextUI = GameObject.FindGameObjectWithTag ("ScoreTextTag");
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
			if (ScoreTextUI.GetComponent<GameScore> ().Score > 0) 
			{
				ScoreTextUI.GetComponent<GameScore> ().Score -= 50;
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "PlayerShipTag" || col.tag == "PlayerBulletTag") 
		{
			PlayExplosion ();
			Destroy (gameObject);
			ScoreTextUI.GetComponent<GameScore> ().Score += 100;
		} 
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionPrefab);
		explosion.transform.position = transform.position;
	}
}

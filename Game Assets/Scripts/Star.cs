using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour 
{
	public float speed;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = transform.position;

		transform.position = new Vector2 (pos.x, pos.y - speed * Time.deltaTime);

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.y < min.y) 
		{
			transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		}
	}
}

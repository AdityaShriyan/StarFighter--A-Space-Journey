using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour 
{
	public GameObject StarPrefab;
	public int MaxStars;
	// Use this for initialization
	void Start () 
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		for (int i = 0; i < MaxStars; i++) 
		{
			GameObject star = (GameObject)Instantiate (StarPrefab);
			star.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
			star.GetComponent<Star>().speed = 1f * Random.value + 0.5f;
			star.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

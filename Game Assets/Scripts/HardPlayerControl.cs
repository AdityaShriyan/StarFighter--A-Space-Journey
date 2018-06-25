using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardPlayerControl : MonoBehaviour 
{
	public GameObject GameManager;

	public float speed;
	public GameObject BulletPrefab;
	public GameObject BulletShooter1;
	public GameObject ExplosionPrefab;

	public GameObject InitialPos;

	public Text LivesUIText;

	const int MaxLives = 3;//Max lives of player
	int lives;//Player's current count of lives

	public void Init ()
	{
		lives = MaxLives;
		LivesUIText.text = lives.ToString ();

		transform.position = InitialPos.transform.position;

		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//------------SHOOTING--------------------------------
		if (Input.GetKeyDown ("space")) 
		{
			GameObject Bullet1 = (GameObject)Instantiate (BulletPrefab);
			Bullet1.transform.position = BulletShooter1.transform.position;
		}
		//-----------MOVEMENT---------------------------------
		float x = Input.GetAxisRaw ("Horizontal");// The value will be -1,0 or 1 for left, no input and right respectively
		//float y = Input.GetAxisRaw ("Vertical");// The value will be -1,0 or 1 for down, no input and up respectively
		//Vector2 direction = new Vector2 (x,y).normalized;
		Move (x);
	}
	void Move(float x)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.2f;
		min.x = min.x + 0.2f;

		Vector2 pos = transform.position;

		pos.x = pos.x + (x * speed * Time.deltaTime);

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);

		transform.position = new Vector2 (pos.x , pos.y);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "EnemyShipTag" || col.tag == "EnemyBulletTag") 
		{
			PlayExplosion ();
			gameObject.SetActive (false);
			lives--;
			LivesUIText.text = lives.ToString ();
			if (lives == 0) {
				GameManager.GetComponent<GameManager> ().SetGameManagerState (global::GameManager.GameManagerState.GameOver);
			} 
			else 
			{
				Invoke("Respawn",2f);
			}
		}
	}

	void Respawn()
	{
		transform.position = InitialPos.transform.position;
		gameObject.SetActive (true);
	}
		

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionPrefab);
		explosion.transform.position = transform.position;
	}
}

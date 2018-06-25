using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public GameObject TitleUI;
	public GameObject PlayButton;
	public GameObject PlayerShip;
	public GameObject EnemySpawner;
	public GameObject GetReadyUI;
	public GameObject GamePlayUI;
	public GameObject ScoreTextUI;
	public GameObject GameOverUI;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () 
	{
		GMState = GameManagerState.Opening;
		Screen.SetResolution(420,540,false);
	}
	
	void UpdateGameManagerState ()
	{
		switch (GMState) 
		{
		case GameManagerState.Opening:
			PlayButton.SetActive (true);
			TitleUI.SetActive (true);
			TitleUI.GetComponent<AudioSource> ().mute = false;
			GamePlayUI.SetActive (false);
			GameOverUI.SetActive (false);
			break;

		case GameManagerState.Gameplay:
			PlayButton.SetActive (false);
			TitleUI.SetActive (false);
			TitleUI.GetComponent<AudioSource> ().mute = true;
			ScoreTextUI.GetComponent<GameScore> ().Score = 0;
			GamePlayUI.SetActive (true);
			GetReadyUI.SetActive (true);
			Invoke ("StartGame", 2f);
			break;

		case GameManagerState.GameOver:
			EnemySpawner.GetComponent<EnemySpawnControl> ().StopEnemySpawning ();
			GameOverUI.SetActive (true);
			Invoke ("ChangeToOpeningState", 4f);
			break;
		}
	}

	void StartGame ()
	{
		GetReadyUI.SetActive (false);
		PlayerShip.GetComponent<HardPlayerControl>().Init ();
		EnemySpawner.GetComponent<EnemySpawnControl> ().StartEnemySpawning ();
	}

	public void SetGameManagerState (GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGameplay()
	{
		SetGameManagerState (GameManagerState.Gameplay);
	}

	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}
}

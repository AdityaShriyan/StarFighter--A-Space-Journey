using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour 
{
	public Text ScoreTextUI;

	int score;

	public int Score
	{
		get 
		{
			return this.score;
		}
		set 
		{
			this.score = value;
			UpdateScoreTextUI();
		}
	}
	// Use this for initialization
	void Start () 
	{
		//ScoreTextUI = GetComponent<Text> ();
	}

	void UpdateScoreTextUI ()
	{
		string scorestr = string.Format ("{0:00000000}", score);
		ScoreTextUI.text = scorestr;
	}
}

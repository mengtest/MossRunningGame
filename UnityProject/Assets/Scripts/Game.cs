using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private bool gameRunning;
	private GameObject player;
	private PlayerBehaviour playerBehaviour;
	private ScoreBehaviour score;
	
	private LevelGenerator levelGenerator;
	
	void Start ()
	{
		GameObject scoreText = GameObject.Find("ScoreText");
		this.score = scoreText.GetComponent("ScoreBehaviour") as ScoreBehaviour;

		this.player = GameObject.FindGameObjectWithTag("Player");
		this.playerBehaviour = this.player.GetComponent("PlayerBehaviour") as PlayerBehaviour;
		this.levelGenerator = new LevelGenerator();		
		this.gameRunning = true;

	}
	
	void Update ()
	{
		if(this.gameRunning)
		{
			this.levelGenerator.Update();
			this.UpdateScore();
			this.CheckGameOver();
		}
	}

	void UpdateScore ()
	{
		this.score.UpdateText( this.playerBehaviour.coinsCollected.ToString() );
	}

	void CheckGameOver ()
	{
		if(this.player.transform.localPosition.x<-15)
		{
			this.gameRunning = false;
			Debug.Log ("Game Over");
			Application.LoadLevel("Menu");
		}
	}
}


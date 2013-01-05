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

		this.levelGenerator = new LevelGenerator();		
		this.gameRunning = true;

		// Listen for coin collection event
		this.playerBehaviour = this.player.GetComponent("PlayerBehaviour") as PlayerBehaviour;
		this.playerBehaviour.coinCollected += new PlayerBehaviour.CoinCollectedHandler( HandleCoinsCollected );
	}
	
	void Update ()
	{
		if(this.gameRunning)
		{
			this.levelGenerator.Update();
			this.CheckGameOver();
		}
	}

	public void HandleCoinsCollected( int total_coins )
	{
		this.score.UpdateText( total_coins.ToString() );
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


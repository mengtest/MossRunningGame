using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	private bool gameRunning;
	private GameObject player;
	
	private LevelGenerator levelGenerator;
	
	void Start ()
	{
		this.player = GameObject.FindGameObjectWithTag("Player");
		this.levelGenerator = new LevelGenerator();		
		this.gameRunning = true;
	}
	
	void Update ()
	{
		if(this.gameRunning)
		{
			this.levelGenerator.Update();
			this.CheckGameOver();
		}
	}
	
	void CheckGameOver ()
	{
		if(this.player.transform.localPosition.x<-15)
		{
			this.gameRunning = false;
			Debug.Log ("Game Over");
		}
	}
}


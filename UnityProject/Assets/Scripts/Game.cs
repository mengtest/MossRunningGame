using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	private bool gameRunning;
	private GameObject player;
	
	private LevelGenerator levelGenerator;
	
	// Use this for initialization
	void Start ()
	{
		this.player = GameObject.FindGameObjectWithTag("Player");
		
		this.levelGenerator = new LevelGenerator();
		
		this.gameRunning = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(this.gameRunning)
		{
			this.levelGenerator.update();
			this.checkGameOver();
		}
	}
	
	void checkGameOver ()
	{
		if(this.player.transform.localPosition.x<-15)
		{
			this.gameRunning = false;
			Debug.Log ("Game Over");
		}
	}
}


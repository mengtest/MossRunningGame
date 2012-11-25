using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	private GameObject player;
	
	private LevelGenerator levelGenerator;
	
	// Use this for initialization
	void Start ()
	{
		//this.player = GameObject.FindGameObjectWithTag("Player");
		
		this.levelGenerator = new LevelGenerator();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.levelGenerator.update();
	}
}




public class GameRules
{
	
	public GameRules()
	{
	}
	
	public void update()
	{
	}
		
}
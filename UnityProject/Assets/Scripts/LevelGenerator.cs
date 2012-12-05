using UnityEngine;
using System.Collections;

/**
 * Adds obstacles in the way of the player character.
 */
public class LevelGenerator
{
	private int elapsed = 0;
	
	private ObstacleFactory factory;
	
	public LevelGenerator()
	{
		this.factory = new ObstacleFactory();
	}
	
	public void update()
	{
		if(this.elapsed % 120 == 0)
		{
			Debug.Log( "make fence!");
			this.factory.makeObstacle();
		}
		if(this.elapsed % 90 == 0)
		{
			Debug.Log ("make coin!");
			this.factory.makeCoin();
		}
		
		this.elapsed++;
	}
	
}



internal class ObstacleFactory
{
	private GameObject primordialCrate;
	private GameObject primordialCoin;
	
	public ObstacleFactory()
	{
		this.primordialCrate = GameObject.Find("PrimordialCrate");
		this.primordialCoin = GameObject.Find("PrimordialCoin");
		ObstacleBehaviour fb = this.primordialCrate.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.garbageCollectable = false;
	}
	
	public GameObject makeObstacle( )
	{
		GameObject obstacle = (GameObject)GameObject.Instantiate( this.primordialCrate );
		obstacle.transform.position = new Vector3(30,1,0);
		
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		
		return obstacle;
	}
	
	public GameObject makeCoin( )
	{
		if(this.primordialCoin)
		{
			GameObject coin = (GameObject)GameObject.Instantiate( this.primordialCoin );
			coin.transform.position = new Vector3(30,6,0);		
			
			ObstacleBehaviour fb = coin.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
			fb.speed = -0.15f;
			fb.garbageCollectable = true;
			
			return coin;
		}
		else
		{
			return null;
		}
	}
}
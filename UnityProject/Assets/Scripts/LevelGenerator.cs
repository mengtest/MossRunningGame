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
			Debug.Log( "make crate!");
			this.factory.makeObstacle();
		}
		if(this.elapsed % 90 == 0)
		{
			Debug.Log ("make coin!");
			this.factory.makeCoin();
		}
		if(this.elapsed % 40 == 0)
		{
			Debug.Log( "make fence!");
			this.factory.makeBackgroundFence();
		}
		
		this.elapsed++;
	}
	
}



internal class ObstacleFactory
{
	private GameObject primordialCrate;
	private GameObject primordialCoin;
	private GameObject primordialFence;
	
	public ObstacleFactory()
	{
		this.primordialCrate = GameObject.Find("PrimordialCrate");
		this.primordialCoin = GameObject.Find("PrimordialCoin");
		this.primordialFence = GameObject.Find("BackgroundFence");
		
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
	
	public GameObject makeBackgroundFence()
	{
		if(this.primordialFence)
		{
			GameObject obstacle = (GameObject)GameObject.Instantiate( this.primordialFence );
			Vector3 pos = this.primordialFence.transform.position;
			obstacle.transform.position = new Vector3(pos.x, pos.y, pos.z);
			
			BackgroundFence fb = obstacle.GetComponent("BackgroundFence") as BackgroundFence;
			fb.speed = -0.15f;
			fb.garbageCollectable = true;
			
			return obstacle;
			
		}
		else
		{
			return null;
		}
	}
}
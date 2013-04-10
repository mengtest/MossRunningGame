using UnityEngine;
using System.Collections;

/**
 * Adds obstacles in the way of the player character.
 */
public class LevelGenerator
{
	private int elapsed = 0;
	private ObstacleFactory factory;
	private GameObject treadmill;

	private Queue	pendingObstacles;

	public LevelGenerator( GameObject treadmill )
	{
		this.factory = new ObstacleFactory();
		this.treadmill = treadmill;
		this.pendingObstacles = new Queue();
	}
	
	public void Update()
	{
		string obstacle_type = "";

		if(this.elapsed % 120 == 0 && this.elapsed > 240)
		{
			pendingObstacles.Enqueue("crate");
			//obstacle_type = "crate";
		}
		if(this.elapsed % 90 == 0 && this.elapsed > 0)
		{
			pendingObstacles.Enqueue("coin");
			//obstacle_type = "coin";
		}
		if(this.elapsed % 106 == 0 )
		{
			pendingObstacles.Enqueue("brickwall");
			//obstacle_type = "brickwall";
		}
		if(this.elapsed % 270 == 0 )
		{
			pendingObstacles.Enqueue("wallsign");
			//obstacle_type = "wallsign";
		}

		while(pendingObstacles.Count>0)
		{
			obstacle_type = (string) pendingObstacles.Dequeue();
			GameObject new_obstacle = this.factory.CreateObstacle( obstacle_type );
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.transform;
		}

		/*
		if(obstacle_type!="")
		{
			GameObject new_obstacle = this.factory.CreateObstacle( obstacle_type );
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.transform;
		}*/

		this.elapsed++;
	}
	
}
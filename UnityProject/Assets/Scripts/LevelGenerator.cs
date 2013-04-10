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
			System.Random rnd = new System.Random();
			int rnd_number = rnd.Next(0,2);

			Debug.Log("rnd_number:"+rnd_number);

			if(rnd_number<1)
			{
				pendingObstacles.Enqueue("crate");
			}
			else
			{
				pendingObstacles.Enqueue("wallsign");
			}
		}

		if(this.elapsed % 90 == 0 && this.elapsed > 0)
		{
			pendingObstacles.Enqueue("coin");
		}
		if(this.elapsed % 106 == 0 )
		{
			pendingObstacles.Enqueue("brickwall");
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
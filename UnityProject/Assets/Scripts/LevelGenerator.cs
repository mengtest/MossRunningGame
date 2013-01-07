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
	public LevelGenerator( GameObject treadmill )
	{
		this.factory = new ObstacleFactory();
		this.treadmill = treadmill;
	}
	
	public void Update()
	{

		string obstacle_type = "";

		if(this.elapsed % 120 == 0 && this.elapsed > 240)
		{
			obstacle_type = "crate";
		}
		if(this.elapsed % 90 == 0 && this.elapsed > 0)
		{
			obstacle_type = "coin";
		}
		if(this.elapsed % 106 == 0 )
		{
			obstacle_type = "brickwall";
		}

		if(obstacle_type!="")
		{
			GameObject new_obstacle = this.factory.CreateObstacle( obstacle_type );
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.transform;
		}

		this.elapsed++;
	}
	
}
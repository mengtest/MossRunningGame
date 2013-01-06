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
	
	public void Update()
	{
		if(this.elapsed % 120 == 0 && this.elapsed > 240)
		{
			this.factory.TriggerObstacle("crate");
		}
		if(this.elapsed % 90 == 0 && this.elapsed > 0)
		{
			this.factory.TriggerObstacle("coin");
		}
		if(this.elapsed % 106 == 0 )
		{
			this.factory.TriggerObstacle("brickwall");
		}

		this.elapsed++;
	}
	
}
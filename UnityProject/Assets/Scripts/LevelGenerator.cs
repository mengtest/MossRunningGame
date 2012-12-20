using UnityEngine;
using System.Collections;

/**
 * Adds obstacles in the way of the player character.
 */
public class LevelGenerator
{
	private int elapsed = 0;
	private ObstacleFactory factory;
	private float _fenceInterval = 40.0f;
	
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
		if(this.elapsed % this._fenceInterval == 0)
		{
			this.factory.TriggerObstacle("fence");
		}
		if(this.elapsed % 60 == 0 )
		{
			this.factory.TriggerObstacle("bush");
		}
		/*if(this.elapsed % 320 == 0 && this.elapsed > 0)
		{
			this.factory.setCameraSpeed( this.factory.getCameraSpeed() * 1.1f );
			this._fenceInterval = Mathf.Round( this._fenceInterval / 1.1f );
		}*/
		this.elapsed++;
	}
	
}
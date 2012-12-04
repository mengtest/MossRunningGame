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
			this.factory.makeFence();
		}
		
		this.elapsed++;
	}
	
}



internal class ObstacleFactory
{
	private GameObject primordialCrate;
	
	public ObstacleFactory()
	{
		this.primordialCrate = GameObject.Find("PrimordialCrate");
		ObstacleBehaviour fb = this.primordialCrate.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.garbageCollectable = false;
	}
	
	public GameObject makeFence( )
	{
		GameObject new_fence = (GameObject)GameObject.Instantiate( this.primordialCrate );
		new_fence.transform.position = new Vector3(30,1,0);		
		
		ObstacleBehaviour fb = new_fence.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		return new_fence;
	}
}
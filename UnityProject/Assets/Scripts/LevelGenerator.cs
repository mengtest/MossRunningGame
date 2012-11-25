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
			this.factory.makeFence();
		}
		
		this.elapsed++;
	}
	
}



internal class ObstacleFactory
{
	private GameObject primordialFence;
	
	public ObstacleFactory()
	{
		this.primordialFence = GameObject.Find("PrimordialFence");
		FenceBehaviour fb = this.primordialFence.GetComponent("FenceBehaviour") as FenceBehaviour;
		fb.garbageCollectable = false;
	}
	
	public GameObject makeFence( )
	{
		GameObject new_fence = (GameObject)GameObject.Instantiate( this.primordialFence );
		new_fence.transform.position = new Vector3(30,0,0);		
		
		FenceBehaviour fb = new_fence.GetComponent("FenceBehaviour") as FenceBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		return new_fence;
	}
}
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
	private GameObject protoCrate;
	private GameObject protoCoin;
	private GameObject protoFence;
	
	private ObjectPool _cratePool;
	private ObjectPool _coinPool;
	private ObjectPool _fencePool;
	
	public ObstacleFactory()
	{
		this.protoCrate = GameObject.Find("ProtoCrate");
		this.protoCoin = GameObject.Find("ProtoCoin");
		this.protoFence = GameObject.Find("ProtoFence");
		
		this._cratePool = new ObjectPool(6);		
		this.populateObjectPool( this._cratePool, this.protoCrate);
		
		this._coinPool = new ObjectPool(6);		
		this.populateObjectPool( this._coinPool, this.protoCoin);
		
		this._fencePool = new ObjectPool(8);		
		this.populateObjectPool( this._fencePool, protoFence);		
		
		//ObstacleBehaviour fb = this.primordialCrate.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		//fb.garbageCollectable = false;
	}
	
	public GameObject makeObstacle( )
	{
		GameObject obstacle = this._cratePool.getNextObject();
		var pos = this.protoCrate.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		
		return obstacle;
	}
	
	public GameObject makeCoin( )
	{
		GameObject obstacle = this._coinPool.getNextObject();
		var pos = this.protoCoin.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		
		return obstacle;
	}
	
	public GameObject makeBackgroundFence()
	{
		GameObject obstacle = this._fencePool.getNextObject();
		Vector3 pos = this.protoFence.transform.position;
		obstacle.transform.position = new Vector3(pos.x, pos.y, pos.z);
		
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = -0.15f;
		fb.garbageCollectable = true;
		
		return obstacle;			
	}
	
	///////////////////////////////////////////////	
	
	/// <summary>
	/// Populates the specified object pool creating instances of the specified prototype GameObject.
	/// </summary>
	/// <param name='pool'>
	/// ObjectPool.
	/// </param>
	/// <param name='proto'>
	/// Prototype.
	/// </param>
	private void populateObjectPool( ObjectPool pool, GameObject proto )
	{
		Vector3 pos = proto.transform.position;
		for (int i = 0; i < pool.maxQty; i++) {
			GameObject obj = (GameObject)GameObject.Instantiate( proto );
			obj.transform.position = new Vector3(pos.x, pos.y, pos.z);;
			pool.add( obj );
		}
	}
	
}
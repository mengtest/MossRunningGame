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
			this.factory.MakeObstacle();
		}
		if(this.elapsed % 90 == 0 && this.elapsed > 0)
		{
			this.factory.MakeCoin();
		}		
		if(this.elapsed % this._fenceInterval == 0)
		{
			this.factory.MakeFence();
		}
		/*if(this.elapsed % 320 == 0 && this.elapsed > 0)
		{
			this.factory.setCameraSpeed( this.factory.getCameraSpeed() * 1.1f );
			this._fenceInterval = Mathf.Round( this._fenceInterval / 1.1f );
		}*/
		this.elapsed++;
	}
	
}



internal class ObstacleFactory
{
	private float _cameraSpeed = -0.15f;
	
	private GameObject protoCrate;
	private GameObject protoCoin;
	private GameObject protoFence;
	
	private ObjectPool _cratePool;
	private ObjectPool _coinPool;
	private ObjectPool _fencePool;
	private System.Collections.Generic.List<GameObject> _obstaclesList;
	
	public ObstacleFactory()
	{
		this.protoCrate = GameObject.Find("ProtoCrate");
		this.protoCoin = GameObject.Find("ProtoCoin");
		this.protoFence = GameObject.Find("ProtoFence");
		//
		this._obstaclesList = new System.Collections.Generic.List<GameObject>();
		//
		this._cratePool = new ObjectPool(6);		
		this.populateObjectPool( this._cratePool, this.protoCrate);
		//
		this._coinPool = new ObjectPool(6);		
		this.populateObjectPool( this._coinPool, this.protoCoin);
		//
		this._fencePool = new ObjectPool(8);		
		this.populateObjectPool( this._fencePool, protoFence);				
	}
	
	public GameObject MakeObstacle( )
	{
		GameObject obstacle = this._cratePool.getNextObject();
		var pos = this.protoCrate.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		this.initObstacle(obstacle);
		return obstacle;
	}
	
	public GameObject MakeCoin( )
	{
		GameObject obstacle = this._coinPool.getNextObject();
		var pos = this.protoCoin.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		this.initObstacle(obstacle);
		return obstacle;
	}
	
	public GameObject MakeFence()
	{
		GameObject obstacle = this._fencePool.getNextObject();
		Vector3 pos = this.protoFence.transform.position;
		obstacle.transform.position = new Vector3(pos.x, pos.y, pos.z);		
		this.initObstacle(obstacle);
		return obstacle;			
	}
	
	public float getCameraSpeed()
	{
		return this._cameraSpeed;
	}
	public float setCameraSpeed( float speed )
	{
		_cameraSpeed = speed;
		int n = _obstaclesList.Count;
		for (int i = 0; i < n; i++) {
			this.updateSpeed( _obstaclesList[i] );
		}
		return this._cameraSpeed;
	}
	
	///////////////////////////////////////////////	
	
	private void initObstacle( GameObject obstacle )
	{
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.running = true;
		fb.speed = this._cameraSpeed;
		fb.garbageCollectable = true;		
	}
	
	private void updateSpeed( GameObject obstacle )
	{
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = this._cameraSpeed;
	}
	
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
			this._obstaclesList.Add ( obj );
		}
	}
	
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class ObstacleFactory
{
	private float _cameraSpeed = -0.15f;
	
	private GameObject protoCrate;
	private GameObject protoCoin;
	private GameObject protoFence;
	private GameObject protoBush;
	
	private Dictionary<string, ObjectPool> _objectPools;
	private ObjectPool _cratePool;
	private ObjectPool _coinPool;
	private ObjectPool _fencePool;
	private ObjectPool _bushPool;
	
	public ObstacleFactory()
	{
		this.protoCrate = GameObject.Find("ProtoCrate");
		this.protoCoin = GameObject.Find("ProtoCoin");
		this.protoFence = GameObject.Find("ProtoFence");
		this.protoBush = GameObject.Find ("ProtoBush");
		//
		this._cratePool = new ObjectPool(this.protoCrate, 3);
		this._coinPool =  new ObjectPool(this.protoCoin,  3);
		this._fencePool = new ObjectPool(this.protoFence, 8);
		this._bushPool =  new ObjectPool(this.protoBush,  5);
		//
		_objectPools = new Dictionary<string, ObjectPool>();
		_objectPools.Add("crate", this._cratePool);
		_objectPools.Add("coin", this._coinPool);
		_objectPools.Add("fence", this._fencePool);
		_objectPools.Add("bush", this._bushPool);
		
	}
	
	public GameObject TriggerObstacle( string type )
	{
		ObjectPool pool = _objectPools[type];
		return MakeObject (pool);			
	}
	
	public GameObject MakeObject( ObjectPool pool )
	{
		GameObject obstacle = pool.getNextObject();
		var pos = pool.prototype.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		this.initObstacle(obstacle);
		return obstacle;
	}
	
	public GameObject MakeObstacle( )
	{
		GameObject obstacle = this._cratePool.getNextObject();
		var pos = this.protoCrate.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		this.initObstacle(obstacle);
		return obstacle;
	}
	
	public GameObject MakeBush( )
	{
		GameObject obstacle = this._bushPool.getNextObject();
		var pos = this.protoBush.transform.position;
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
		this.updateSpeedInPool( this._cratePool );
		this.updateSpeedInPool( this._coinPool );
		this.updateSpeedInPool( this._fencePool );
		this.updateSpeedInPool( this._bushPool );
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
	
	private void updateSpeedInPool( ObjectPool pool )
	{
		int n = pool.list.Count;
		for (int i = 0; i < n; i++) {
			this.updateSpeed( pool.list[i] );
		}
	}
	
	private void updateSpeed( GameObject obstacle )
	{
		ObstacleBehaviour fb = obstacle.GetComponent("ObstacleBehaviour") as ObstacleBehaviour;
		fb.speed = this._cameraSpeed;
	}
	
}
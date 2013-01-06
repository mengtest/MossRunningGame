using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class ObstacleFactory
{
	private float _cameraSpeed = -0.15f;
	
	private Dictionary<string, ObjectPool> _objectPools;
	
	public ObstacleFactory()
	{
		_objectPools = new Dictionary<string, ObjectPool>();
		_objectPools.Add("crate", 		new ObjectPool(GameObject.Find("ProtoCrate"),		3));
		_objectPools.Add("coin",  		new ObjectPool(GameObject.Find("ProtoCoin"),		3));
		_objectPools.Add("fence", 		new ObjectPool(GameObject.Find("ProtoFence"),		8));
		_objectPools.Add("bush",  		new ObjectPool(GameObject.Find("ProtoBush"),		5));
		_objectPools.Add("brickwall",	new ObjectPool(GameObject.Find("ProtoBrickWall"),	4));
	}
	
	public GameObject TriggerObstacle( string type )
	{
		ObjectPool pool = _objectPools[type];
		return GetObstacle (pool);			
	}	
	
	public float getCameraSpeed()
	{
		return this._cameraSpeed;
	}
	
	///////////////////////////////////////////////	
	
	private GameObject GetObstacle( ObjectPool pool )
	{
		GameObject obstacle = pool.getNextObject();
		var pos = pool.prototype.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		this.initObstacle(obstacle);
		return obstacle;
	}

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
	
}
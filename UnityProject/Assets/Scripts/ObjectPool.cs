using UnityEngine;
using System.Collections;

public class ObjectPool
{
	private GameObject _prototype;
	private uint _maxQty;
	private System.Collections.Generic.Queue<GameObject> _queue;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ObjectPool"/> class.
	/// </summary>
	/// <param name='max_qty'>
	/// Max_qty.
	/// </param>
	public ObjectPool( GameObject prototype, uint max_qty )
	{
		_prototype = prototype;
		_maxQty = max_qty;
		_queue = new System.Collections.Generic.Queue<GameObject>();
		this.populate();
	}
	
	public GameObject getNextObject()
	{
		if(_queue.Count>0)
		{
			GameObject item = this._queue.Dequeue();
			this._queue.Enqueue(item);
			return item;
		}
		else
		{
			return null;
		}
	}
	
	///////////////
	
	private void populate()
	{
		Vector3 pos = _prototype.transform.position;
		for (int i = 0; i < this.maxQty; i++) {
			GameObject obj = (GameObject)GameObject.Instantiate( _prototype );
			obj.transform.position = new Vector3(pos.x, pos.y, pos.z);
			this._queue.Enqueue(obj);
		}
	}	
	
	///////////////
	
	public uint maxQty
	{
		get { return _maxQty;	}
	}
	
	public GameObject prototype
	{
		get { return _prototype; }
	}
	
}
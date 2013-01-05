using UnityEngine;
using System.Collections;

public class ObjectPool
{
	private GameObject _prototype;
	private uint _maxQty;
	private System.Collections.Generic.List<GameObject> _list;
	
	
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
		_list = new System.Collections.Generic.List<GameObject>();
		this.populate();
	}
	
	public GameObject getNextObject()
	{
		if(_list.Count>0)
		{
			GameObject item = this._list[0];
			this._list.RemoveAt(0);
			this._list.Insert( this._list.Count, item );
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
			this._list.Add(obj);
		}
	}	
	
	///////////////
	
	/// <summary>
	/// Gets the list.
	/// </summary>
	/// <value>
	/// The list.
	/// </value>
	public System.Collections.Generic.List<GameObject> list
	{
		get { return _list;	}
	}
	
	/// <summary>
	/// Gets the max qty.
	/// </summary>
	/// <value>
	/// The max qty.
	/// </value>
	public uint maxQty
	{
		get { return _maxQty;	}
	}
	
	public GameObject prototype
	{
		get { return _prototype; }
	}
	
}


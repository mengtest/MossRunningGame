using UnityEngine;
using System.Collections;

public class ObjectPool
{
	private uint _maxQty;
	private System.Collections.Generic.List<GameObject> _list;
	
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ObjectPool"/> class.
	/// </summary>
	/// <param name='max_qty'>
	/// Max_qty.
	/// </param>
	public ObjectPool( uint max_qty )
	{
		_maxQty = max_qty;
		_list = new System.Collections.Generic.List<GameObject>();
	}
	
	public bool add( GameObject obj )
	{
		//if(_list.Count < _maxQty)
		//{
			_list.Add(obj);
			return true;
		//}
		//else
		//{
		//	return false;
		//}
	}
	
	public GameObject getNextObject()
	{
		Debug.Log( "count:" + this._list.Count );
		GameObject item = this._list[0];
		this._list.RemoveAt(0);
		this._list.Insert( this._list.Count, item );
		return item;
	}
	
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
	
}


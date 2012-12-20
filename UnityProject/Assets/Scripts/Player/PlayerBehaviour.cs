using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
	private PlayerFSM fsm;	
	
	void Start ()
	{
		this.fsm = new PlayerFSM( this );
		this.fsm.start();
	}
	
	void Update ()
	{
		this.fsm.Update();
	}	
	
	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag=="crate")
		{
			Debug.Log("oh! no! a crate!");
		}
		if(other.gameObject.tag=="coin")
		{
			Debug.Log("yey! a coin!");
		}
	}
	
}
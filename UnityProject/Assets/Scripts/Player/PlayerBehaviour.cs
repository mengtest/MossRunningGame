using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
	
	private PlayerFSM fsm;	
	
	// Use this for initialization
	void Start ()
	{
		this.fsm = new PlayerFSM( this );
		this.fsm.start();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.fsm.Update();
	}
	
	void OnCollisionEnter( Collision collision )
	{
	    //Debug.Log ("collision!!!!!!!!!!");
	}
	
	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag=="crate")
		{
			Debug.Log("oh! no! a crate!");
		}
		if(other.gameObject.tag=="coin")
		{
		}
	}
	
}
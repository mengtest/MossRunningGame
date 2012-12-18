using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour
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
		this.fsm.update();
	}
	
	void OnCollisionEnter( Collision collision )
	{
	    //Debug.Log ("collision!!!!!!!!!!");
	}
	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log ("colliding with " + other);
	}
	
}
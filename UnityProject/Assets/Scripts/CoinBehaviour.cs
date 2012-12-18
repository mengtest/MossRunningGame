using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {
	
	private bool markedToDestroy;
	// Use this for initialization
	void Start () {
		this.markedToDestroy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.markedToDestroy)
		{
			Destroy( this.gameObject );
			Destroy( this );
		}			
	}
	
	//void OnCollisionEnter( Collision collision )
	void OnTriggerEnter( Collider other )
	{
	    Debug.Log ("COIN collision! " + other.gameObject.tag );
		
		if(this.gameObject.tag != other.gameObject.tag)
		{
			this.markedToDestroy = true;		
		}
	}	
}

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
	
	void OnCollisionEnter( Collision collision )
	{
	    Debug.Log ("COIN collision!");
		this.markedToDestroy = true;		
	}	
}

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
			AudioSource.PlayClipAtPoint(this.gameObject.audio.clip, this.gameObject.transform.position);
			
			Destroy( this.gameObject );
			Destroy( this );
		}			
	}
	
	//void OnCollisionEnter( Collision collision )
	void OnTriggerEnter( Collider other )
	{
	    
		
		if(other.gameObject.tag == "Player")
		{
			this.markedToDestroy = true;		
			//
			Debug.Log ("COIN collision! " + other.gameObject.tag );
			/*
			if(this.gameObject.audio)
			{
				if(!this.gameObject.audio.isPlaying)
				{
					this.gameObject.audio.Play();
				}
			}*/
		}
	}	
}

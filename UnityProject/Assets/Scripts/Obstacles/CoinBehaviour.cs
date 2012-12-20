using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	//void OnCollisionEnter( Collision collision )
	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag == "Player")
		{			
			if(this.gameObject.audio)
			{
				if(!this.gameObject.audio.isPlaying)
				{
					this.gameObject.audio.Play();
				}
			}
			this.gameObject.transform.Translate( new Vector3(0,0,-10) ); // hiding it off screen			
		}
	}	
}

using UnityEngine;
using System.Collections;

public class CrateBehaviour : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnTriggerEnter( Collider other )
	{
		if(this.gameObject.audio)
		{
			if(!this.gameObject.audio.isPlaying)
			{
				this.gameObject.audio.Play();
			}
		}
	}
	
	void OnTriggerStay( Collider other )
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.gameObject.transform.position.x < this.gameObject.transform.position.x)
			{
				// push player back
				Vector3 pos = other.gameObject.transform.position;
				pos.x = pos.x - 0.30f;		
				other.gameObject.transform.position = pos;
			}
		}		
	}
	
}


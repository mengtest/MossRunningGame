using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {
	
	public bool garbageCollectable = true;
	public float leftsideBound = -20.0f;
	public float speed = -0.15f;
	public bool running = false;
	
	void Start () {
	}
	
	void Update ()
	{		
		if(this.running) 
		{
			this.gameObject.transform.Translate( this.speed,0f,0f);			
			// check removal position
			Vector3 pos = this.gameObject.transform.position;
			if( pos.x < this.leftsideBound )
			{
				this.running = false;
			}
		}
	}	
	
}

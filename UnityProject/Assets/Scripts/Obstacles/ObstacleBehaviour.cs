using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {
	
	public bool garbageCollectable = true;
	public float speed = 0f;
	public float leftsideBound = -20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{		
		this.gameObject.transform.Translate( this.speed,0f,0f);
	
		// check removal position
		
		Vector3 pos = this.gameObject.transform.position;
		if( pos.x < this.leftsideBound )
		{
			this.speed = 0;
		}
	}	
	
	
}

using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {
	
	public bool garbageCollectable = true;
	public float speed = -0.15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		this.gameObject.transform.Translate( this.speed,0f,0f);
	
		// check collisions here? ow what?
		
		
		// check removal position
		
		Vector3 pos = this.gameObject.transform.position;
		if( pos.x < -20 )
		{
			if(this.garbageCollectable)
			{
				Destroy( this.gameObject );
				Destroy( this );
			}
			this.speed = 0;
		}
	}
}

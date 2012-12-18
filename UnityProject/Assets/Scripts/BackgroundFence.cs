using UnityEngine;
using System.Collections;

public class BackgroundFence : MonoBehaviour {

	public bool garbageCollectable = true;
	public float speed = -0.15f;

	// Use this for initialization
	void Start () {
		Debug.Log("NEW FENCE");
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.Translate( this.speed,0f,0f);
	
		// check removal position
		
		Vector3 pos = this.gameObject.transform.position;
		if( pos.x < -30 )
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

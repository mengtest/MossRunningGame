using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {
	
	public float leftsideBound = -20.0f;

	void Start () {
	}
	
	void Update ()
	{		
		// check removal position
		Vector3 pos = this.gameObject.transform.position;
		if( pos.x < this.leftsideBound )
		{
			this.gameObject.transform.parent = null;
		}
	}	
	
}

using UnityEngine;
using System.Collections;

public class TreadmillBehaviour : MonoBehaviour {

	public float speed = -0.15f;
	public bool running = false;

	void Start ()
	{
	
	}

	void Update ()
	{
		if(this.running)
		{
			this.gameObject.transform.Translate( this.speed,0f,0f);
		}

	}
}

using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
	private PlayerFSM fsm;	

	public int coinsCollected;

	void Start ()
	{
		this.coinsCollected = 0;
		this.fsm = new PlayerFSM( this );
		this.fsm.start();
	}
	
	void Update ()
	{
		this.fsm.Update();
	}	
	
	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag=="crate")
		{
			//Debug.Log("oh! no! a crate!");
		}
		if(other.gameObject.tag=="coin")
		{
			this.coinsCollected++;
		}
	}
	
}
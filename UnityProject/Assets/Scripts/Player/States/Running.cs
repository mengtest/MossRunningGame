using UnityEngine;
using System.Collections;

public class Running : PlayerState
{
	public Running (PlayerFSM fsm, PlayerBehaviour character) : base( fsm, character )
	{
		this.animation = new RunningAnimation (character.gameObject); 		
	}
	
	public override void Start ()
	{
		base.Start ();
		this.character.velocity.y = 0;
		//
		Vector3 pos = this.character.gameObject.transform.position;
		if (pos.y < 0) {
			pos.y = 0;
			this.character.gameObject.transform.position = pos;
		}
	}

	public override void Update ()
	{
		//
		bool up = Input.GetKeyDown (KeyCode.UpArrow);
		bool dwn = Input.GetKeyDown (KeyCode.DownArrow);
		//bool k = Input.anyKey;
		if (up && !dwn) {
			this.fsm.GoJumping ();
		}
		if (dwn && !up) {
			this.fsm.GoSliding ();
		}
		//
		base.Update ();
	}
}

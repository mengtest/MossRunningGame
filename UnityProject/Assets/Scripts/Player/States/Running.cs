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

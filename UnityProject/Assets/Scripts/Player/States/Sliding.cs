using UnityEngine;
using System.Collections;

public class Sliding : PlayerState
{
	private int elapsed = 0;
	private int duration = 45;

	public Sliding (PlayerFSM fsm, PlayerBehaviour character) : base( fsm, character )
	{
		this.animation = new SlidingAnimation (this.character.gameObject);
	}

	public override void Start ()
	{
		this.elapsed = 0;
		base.Start ();
		this.character.velocity.y = 0;
	}

	public override void Update ()
	{
		this.elapsed ++;
		//
		base.Update ();
		//
		if (this.elapsed >= this.duration) {
			this.fsm.GoRunning ();
		}
	}

	public override void End ()
	{
		this.elapsed = 0;
	}

}
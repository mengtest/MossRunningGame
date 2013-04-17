using UnityEngine;
using System.Collections;

public class Falling : PlayerState
{
	private int elapsed = 0;
	private int duration = 45;

	public Falling (PlayerFSM fsm, PlayerBehaviour character) : base( fsm, character )
	{
		this.animation = new RunningAnimation (this.character.gameObject);
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
		this.character.velocity.y += this.character.gravity.y;
		this.character.velocity.x += this.character.gravity.x;
		//
		base.Update ();
		//
		if (this.elapsed >= this.duration) {
			// end game!!!
			this.character.KillPlayer ();
		}
	}

	public override void End ()
	{
		this.elapsed = 0;
	}

	protected override void AdjustHorizontalSpeed()
	{
	}

}
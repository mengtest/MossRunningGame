using UnityEngine;
using System.Collections;

public class Jumping : PlayerState
{
	private float jumpSpeed = 0.16f;
	private int elapsed = 0;
	private float impulseLimit = 15f;
	private float extraImpulse = 0.08f;

	public Jumping (PlayerFSM fsm, PlayerBehaviour character) : base( fsm, character )
	{
		this.animation = new JumpingAnimation (this.character.gameObject);
		//this.animation = new SlidingAnimation( this.character.gameObject );
	}
	
	public override void Start ()
	{
		this.elapsed = 0;
		base.Start ();
		this.character.velocity.y = this.jumpSpeed;
	}

	public override void Update ()
	{
		this.elapsed ++;
		//
		this.character.velocity.y += this.character.gravity.y;
		this.character.velocity.x += this.character.gravity.x;

		if (this.IsOnGround ()) {
			this.fsm.GoRunning ();
		} else {
			if (Input.anyKey && this.elapsed < this.impulseLimit) {
				this.character.velocity.y += this.jumpSpeed * this.extraImpulse;
			}
		}
		base.Update ();
	}

	public override void End ()
	{
		this.elapsed = 0;
	}

	public bool IsOnGround ()
	{
		Vector3 pos = this.character.gameObject.transform.position;
		return (pos.y < 0);
	}
	
}
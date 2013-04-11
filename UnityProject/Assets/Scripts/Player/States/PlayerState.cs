using UnityEngine;
using System.Collections;

public class PlayerState
{
	protected PlayerFSM fsm;
	protected PlayerBehaviour character;
	protected CharAnimation animation; // It's probably best to use Blender animations instead of this, but I haven't got the time to learn to animate in Blender yet.

	public PlayerState (PlayerFSM fsm, PlayerBehaviour character)
	{
		this.fsm = fsm;
		this.character = character;

	}

	public virtual void Start ()
	{
		if (this.animation != null)
			this.animation.Start ();
	}

	public virtual void Update ()
	{
		if (this.animation != null)
			this.animation.Update ();
		//
		this.ApplyVelocity ();
	}

	public virtual void End ()
	{
	}

	private void ApplyVelocity ()
	{
		Vector3 pos = this.character.transform.localPosition;
		//
		// Speed up character if it's near the left edge of the screen.
		float center = -5.0f;
		if (pos.x < center)
			this.character.velocity.x = 0.005f * (center - pos.x);
		else
			this.character.velocity.x = 0.000f;
		//
		pos.x = pos.x + this.character.velocity.x;
		pos.y = pos.y + this.character.velocity.y;
		pos.z = 0;

		this.character.gameObject.transform.position = pos;
	}
}
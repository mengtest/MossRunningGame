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
		Vector3 pos = this.character.transform.localPosition;
		
		float center = -5.0f;
		float pos_x = pos.x;
		if (pos_x < center)
			pos_x += 0.005f * (center - pos_x);
		float pos_y = pos.y + this.character.velocity.y;

		this.SetCharacterPos (pos_x, pos_y, 0);
	}

	public virtual void End ()
	{
	}
	
	protected void SetCharacterPos (float x, float y, float z)
	{
		Vector3 pos = this.character.gameObject.transform.position;
		pos.x = x;
		pos.y = y;
		pos.z = z;
		this.character.gameObject.transform.position = pos;		
	}
}

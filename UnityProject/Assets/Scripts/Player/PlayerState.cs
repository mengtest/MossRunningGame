// Multiple clases in this file.
// PlayerState and some sub-classes: Running and Jumping, for now.

using UnityEngine;
using System.Collections;

public class PlayerState
{
	protected PlayerFSM fsm;
	protected PlayerBehaviour character;

	protected CharAnimation animation; // It's probably best to use Blender animations instead of this, but I haven't got the time to learn to animate in Blender yet.
	
	public PlayerState( PlayerFSM fsm, PlayerBehaviour character )
	{
		this.fsm = fsm;
		this.character = character;
	}
	public virtual void Start()
	{
		if(this.animation!=null) this.animation.Start();
	}
	public virtual void Update()
	{
		if(this.animation!=null) this.animation.Update();
		//
		Vector3 pos = this.character.transform.localPosition;
		
		float center = -5.0f;
		float pos_x = pos.x;
		if(pos_x<center) pos_x += 0.005f * (center - pos_x);
		float pos_y = pos.y + this.character.velocity.y;

		this.SetCharacterPos(pos_x, pos_y, 0);
	}
	public virtual void End()
	{
	}	
	
	protected void SetCharacterPos( float x, float y, float z )
	{
		Vector3 pos = this.character.gameObject.transform.position;
		pos.x = x;
		pos.y = y;
		pos.z = z;
		this.character.gameObject.transform.position = pos;		
	}
}

internal class Running : PlayerState
{
	public Running( PlayerFSM fsm, PlayerBehaviour character ) : base( fsm, character )
	{
		this.animation = new RunningAnimation( character.gameObject ); 		
	}	
	
	public override void Start()
	{
		base.Start();
		this.character.velocity.y = 0;
	}
	public override void Update()
	{
		//
		bool k = Input.anyKey;
		if(k)
		{
			this.fsm.GoJumping();
		}
		//
		base.Update();
	}
}

internal class Jumping : PlayerState
{
	private float jumpSpeed = 0.35f;
	private int elapsed = 0;

	public Jumping( PlayerFSM fsm, PlayerBehaviour character ) : base( fsm, character )
	{
		this.animation = new JumpingAnimation( this.character.gameObject );
	}	
	
	public override void Start()
	{
		this.elapsed = 0;
		base.Start();
		this.character.velocity.y = this.jumpSpeed;
	}
	public override void Update()
	{
		this.elapsed ++;
		//
		this.character.velocity.y += this.character.gravity.y;
		this.character.velocity.x += this.character.gravity.x;

		if(this.IsOnGround())
		{
			this.fsm.GoRunning();
		}
		base.Update();
	}
	public override void End()
	{
		this.elapsed = 0;
	}
	public bool IsOnGround()
	{
		Vector3 pos = this.character.gameObject.transform.position;
		if(pos.y<0)
		{
			pos.y = 0;
			this.character.gameObject.transform.position = pos;
			return true;
		}
		return false;
	}
	
}

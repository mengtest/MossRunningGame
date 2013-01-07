// Multiple clases in this file.
// PlayerState and some sub-classes: Running and Jumping, for now.

using UnityEngine;
using System.Collections;

public class PlayerState
{
	protected PlayerFSM fsm;
	protected PlayerBehaviour character;
	
	protected CharAnimation animation;
	
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
	}
	public virtual void End()
	{
	}	
	
	protected void SetCharacterYPos( float y )
	{
		Vector3 pos = this.character.gameObject.transform.position;
		pos.y = y;
		this.character.gameObject.transform.position = pos;		
	}
}

internal class Running : PlayerState
{
	public Running( PlayerFSM fsm, PlayerBehaviour character ) : base( fsm, character )
	{
		this.animation = new RunningAnimation( character.gameObject ); 		
	}	
	
	public override void Update()
	{
		Vector3 pos = this.character.transform.localPosition;
		pos.z = 0;
		
		float center = -5.0f;
		if(pos.x<center) pos.x += 0.005f * (center - pos.x);
		
		this.character.transform.localPosition = pos;		
		
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
	private int elapsed = 0;	
	private int jumpDuration = 60;
	
	public Jumping( PlayerFSM fsm, PlayerBehaviour character ) : base( fsm, character )
	{
		this.animation = new JumpingAnimation( this.character.gameObject, this.jumpDuration ); 
	}	
	
	public override void Start()
	{
		this.elapsed = 0;
		base.Start();
	}
	public override void Update()
	{
		this.elapsed ++;
		//
		if(this.elapsed>this.jumpDuration)
		{
			this.fsm.GoRunning();
		}
		base.Update();
	}
	public override void End()
	{
		this.elapsed = 0;
	}
	
}

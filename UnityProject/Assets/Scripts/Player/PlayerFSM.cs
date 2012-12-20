using UnityEngine;
using System.Collections;

public class PlayerFSM
{
	private PlayerBehaviour character;
	
	private PlayerState currentState;
	private PlayerState jumpingState;
	private PlayerState runningState;
	
	public PlayerFSM( PlayerBehaviour character )
	{
		this.character = character;
	}
	
	public void start()
	{
		this.runningState = new Running( this, this.character );
		this.jumpingState = new Jumping( this, this.character );
		this.GoRunning();
	}
	
	public void Update()
	{
		this.currentState.Update();
	}
	
	internal void GoRunning()
	{
		this.SetState ( this.runningState );
	}
	internal void GoJumping()
	{
		this.SetState ( this.jumpingState );
	}
	
	private void SetState( PlayerState new_state)
	{
		if(this.currentState!=null) this.currentState.End();
		this.currentState = new_state;
		this.currentState.Start();
	}
		
}


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
		//Debug.Log("PlayerState::SetCharacterYPos " + y);
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
		//this.character.gameObject.transform.Rotate(Mathf.PI/8,Mathf.PI/8,Mathf.PI/8);
		//this.setCharacterYPos(0);
		
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


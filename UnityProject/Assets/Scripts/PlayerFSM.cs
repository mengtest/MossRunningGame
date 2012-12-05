using UnityEngine;
using System.Collections;

public class PlayerFSM
{
	private MainCharacter character;
	
	private PlayerState currentState;
	private PlayerState jumpingState;
	private PlayerState runningState;
	
	public PlayerFSM( MainCharacter character )
	{
		this.character = character;
	}
	
	public void start()
	{
		this.runningState = new Running( this, this.character );
		this.jumpingState = new Jumping( this, this.character );
		this.goRunning();
	}
	
	public void update()
	{
		this.currentState.update();
	}
	
	internal void goRunning()
	{
		this.setState ( this.runningState );
	}
	internal void goJumping()
	{
		this.setState ( this.jumpingState );
	}
	
	private void setState( PlayerState new_state)
	{
		if(this.currentState!=null) this.currentState.end();
		this.currentState = new_state;
		this.currentState.start();
	}
		
}


public class PlayerState
{
	protected PlayerFSM fsm;
	protected MainCharacter character;
	
	protected CharAnimation animation;
	
	public PlayerState( PlayerFSM fsm, MainCharacter character )
	{
		this.fsm = fsm;
		this.character = character;
	}
	public virtual void start()
	{
		if(this.animation!=null) this.animation.start();
	}
	public virtual void update()
	{
		if(this.animation!=null) this.animation.update();
	}
	public virtual void end()
	{
	}	
	
	protected void setCharacterYPos( float y )
	{
		//Debug.Log("PlayerState::setCharacterYPos " + y);
		Vector3 pos = this.character.gameObject.transform.position;
		pos.y = y;
		this.character.gameObject.transform.position = pos;		
	}
}

internal class Running : PlayerState
{
	public Running( PlayerFSM fsm, MainCharacter character ) : base( fsm, character )
	{
		this.animation = new RunningAnimation( character.gameObject ); 		
	}	
	
	public override void update()
	{
		//this.character.gameObject.transform.Rotate(Mathf.PI/8,Mathf.PI/8,Mathf.PI/8);
		//this.setCharacterYPos(0);
		
		Vector3 pos = this.character.transform.localPosition;
		pos.z = 0;
		if(pos.x<-5) pos.x += 0.005f;
		this.character.transform.localPosition = pos;		
		
		//
		bool k = Input.anyKey;
		if(k)
		{
			this.fsm.goJumping();
		}
		//
		base.update();
	}
}



internal class Jumping : PlayerState
{
	private int elapsed = 0;	
	private int jumpDuration = 60;
	
	public Jumping( PlayerFSM fsm, MainCharacter character ) : base( fsm, character )
	{
		this.animation = new JumpingAnimation( this.character.gameObject, this.jumpDuration ); 
	}	
	
	public override void start()
	{
		this.elapsed = 0;
		base.start();
	}
	public override void update()
	{
		this.elapsed ++;
		//
		if(this.elapsed>this.jumpDuration)
		{
			this.fsm.goRunning();
		}
		base.update();
	}
	public override void end()
	{
		this.elapsed = 0;
	}
	
}


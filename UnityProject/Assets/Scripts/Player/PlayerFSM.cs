using UnityEngine;
using System.Collections;

public class PlayerFSM
{
	private PlayerBehaviour character;
	
	private PlayerState currentState;
	private PlayerState jumpingState;
	private PlayerState runningState;
	private PlayerState slidingState;
	
	public PlayerFSM( PlayerBehaviour character )
	{
		this.character = character;
	}
	
	public void start()
	{
		this.runningState = new Running( this, this.character );
		this.jumpingState = new Jumping( this, this.character );
		this.slidingState = new Sliding( this, this.character );
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
	internal void GoSliding()
	{
		this.SetState ( this.slidingState );
	}
	
	private void SetState( PlayerState new_state)
	{
		if(this.currentState!=null) this.currentState.End();
		this.currentState = new_state;
		this.currentState.Start();
	}
		
}
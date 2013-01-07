// Multiple clases in this file.
// CharAnimation and some sub-classes: RunningAnimation and JumpingAnimation, for now.


using UnityEngine;
using System.Collections;

/// <summary>
/// It's probably best to use Blender animations instead of this, but I haven't got the time to learn to animate in Blender yet.
/// </summary>
public class CharAnimation
{
	protected GameObject player;
	
	protected Transform shoulderLeft; 
	protected Transform shoulderRight; 
	protected Transform legLeft;
	protected Transform legRight;
	protected Transform neck;	
	protected Transform head;
	
	protected float head_origin_z;
	
	protected int elapsed = 0;
	
	public CharAnimation( GameObject player )
	{
		this.player = player;
		this.shoulderLeft = this.player.transform.Find("Body/Shoulder-Left");
		this.shoulderRight = this.player.transform.Find("Body/Shoulder-Right");
		this.legLeft = this.player.transform.Find ("Body/Crotch-Left");
		this.legRight = this.player.transform.Find ("Body/Crotch-Right");
		this.neck = this.player.transform.Find ("Neck");
		this.head = this.player.transform.Find ("Neck/Head");
		this.head_origin_z = this.head.localPosition.z;
	}

	// Use this for initialization
	public virtual void Start ()
	{
		this.elapsed = 0;
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
		this.elapsed++;
	}
	
	protected void SetPlayerYPos( float y )
	{
		Vector3 pos = this.player.transform.localPosition;
		pos.y = y;
		this.player.transform.localPosition = pos;
	}
	
	protected void SetHeadYPos( float y )
	{
		Vector3 pos = this.head.localPosition;
		pos.z = y;
		this.head.localPosition = pos;
	}
	
	
	protected void SetJointAngle( Transform tr, float angle )
	{
		Vector3 angles = tr.localEulerAngles;
		angles.y = angle;
		tr.localEulerAngles = angles;
	}
	
}

public class RunningAnimation : CharAnimation
{
	
	private float shoulderCycle = 30; // frames
	private float shoulderAmplitude = 80; // degrees
	private float neckAmplitude = 2.5f; // degrees
	
	public RunningAnimation( GameObject player ) : base( player )
	{
	}
	
	public override void Start()
	{
		this.player.transform.localEulerAngles = new Vector3(275,90,90); // lean character forward a little bit
		
		this.SetHeadYPos( this.head_origin_z );
		//
		base.Start();
	}
	
	public override void Update()
	{
		float r = (float)this.elapsed / shoulderCycle;
		
		float sin = Mathf.Sin ( r * Mathf.PI * 2);
		
		this.SetJointAngle( shoulderLeft,    sin * this.shoulderAmplitude );
		this.SetJointAngle( shoulderRight, - sin * this.shoulderAmplitude );
		
		this.SetJointAngle( legLeft,    sin * this.shoulderAmplitude );
		this.SetJointAngle( legRight, - sin * this.shoulderAmplitude );
		
		float cos = Mathf.Cos( r * Mathf.PI * 2 * 2 );
		this.SetPlayerYPos( cos * 0.1f );
		
		this.RotateHead( r );
		//
		base.Update();
	}
	
	private void RotateHead( float r )
	{
		Vector3 angles = this.neck.localEulerAngles;
		angles.x = Mathf.Sin ( r * Mathf.PI * 2 ) * this.neckAmplitude;
		//angles.y = Mathf.Sin ( r * Mathf.PI * 1 ) * this.neckAmplitude;
		this.neck.localEulerAngles = angles;
	}	
	
}

public class JumpingAnimation : CharAnimation
{
	private int jumpDuration;
	private float jumpHeight = 6.0f;
	
	public JumpingAnimation( GameObject player, int jumpDuration ) : base( player )
	{
		this.jumpDuration = jumpDuration;
	}
	
	public override void Start()
	{
		this.player.transform.localEulerAngles = new Vector3(275,90,90); // lean character forward a little bit
		base.Start();
		this.player.audio.Play();
	}
	
	public override void Update ()
	{
		float r = ((float)this.elapsed) / ((float)this.jumpDuration);
		float py = Mathf.Abs( Mathf.Sin( r * Mathf.PI ) * this.jumpHeight );
		this.SetPlayerYPos( py );
		//
		this.RotateHead( r );
		//
		base.Update ();
	}
	
	private void RotateHead( float r )
	{
		Vector3 angles = this.neck.localEulerAngles;
		angles.z = Mathf.Sin ( r * Mathf.PI  ) * 45;
		this.neck.localEulerAngles = angles;
	}	
	
}


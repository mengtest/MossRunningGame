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
	protected Transform body;
	protected float head_origin_z;
	protected int elapsed = 0;
	
	public CharAnimation (GameObject player)
	{
		this.player = player;
		this.shoulderLeft = this.player.transform.Find ("Body/Shoulder-Left");
		this.shoulderRight = this.player.transform.Find ("Body/Shoulder-Right");
		this.legLeft = this.player.transform.Find ("Body/Crotch-Left");
		this.legRight = this.player.transform.Find ("Body/Crotch-Right");
		this.neck = this.player.transform.Find ("Neck");
		this.head = this.player.transform.Find ("Neck/Head");
		this.head_origin_z = this.head.localPosition.z;
		this.body = this.player.transform.Find ("Body");
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
	
	/*protected void SetPlayerYPos( float y )
	{
		Vector3 pos = this.player.transform.localPosition;
		pos.y = y;
		this.player.transform.localPosition = pos;
	}*/

	protected void RotateHead (float r)
	{
		Vector3 angles = this.neck.localEulerAngles;
		angles.z = Mathf.Sin (r * Mathf.PI) * 45;
		this.neck.localEulerAngles = angles;
	}

	protected void SetHeadYPos (float y)
	{
		Vector3 pos = this.head.localPosition;
		pos.z = y;
		this.head.localPosition = pos;
	}

	protected void SetSlidingPose (float n)
	{
		float sliding_y_pos = -0.75f;

		Vector3 body_pos = this.body.transform.localPosition;
		Vector3 pos = this.player.transform.position;

		float head_rotation_ratio = 0.5f;

		body_pos.x = -0.75f;
		body_pos.z = 0.50f;

		pos.y = sliding_y_pos;

		float body_angle = 90;
		float neck_angle = 45;

		float m = 0;

		if (n <= 0.25f) {
			m = 4 * n;
			body_angle = m * 90.0f;
			pos.y = m * sliding_y_pos;
			neck_angle = m * 45;
			body_pos.x = m * body_pos.x;
			body_pos.z = m * body_pos.z;
			head_rotation_ratio = m * head_rotation_ratio;
		}
		if (n >= 0.875f) {
			m = 8 * (1 - n);
			body_angle = m * 90.0f;
			pos.y = m * sliding_y_pos;
			neck_angle = m * 45;
			body_pos.x = m * body_pos.x;
			body_pos.z = m * body_pos.z;
			head_rotation_ratio = m * head_rotation_ratio;
		}
		this.player.transform.position = pos;
		body_pos.z = body_pos.z + 1;
		this.body.transform.localPosition = body_pos;
		this.SetJointAngle (this.body, body_angle);
		this.SetJointAngle (this.neck, neck_angle);
		this.RotateHead (head_rotation_ratio);

	}
	
	protected void SetJointAngle (Transform tr, float angle)
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
	
	public RunningAnimation (GameObject player) : base( player )
	{
	}
	
	public override void Start ()
	{
		this.SetSlidingPose (0);

		this.player.transform.localEulerAngles = new Vector3 (275, 90, 90); // lean character forward a little bit
		
		this.SetHeadYPos (this.head_origin_z);
		//
		Vector3 neck_angles = this.neck.localEulerAngles;
		neck_angles.x = 0;
		neck_angles.y = 0;
		neck_angles.z = 0;
		this.neck.localEulerAngles = neck_angles;
		//
		base.Start ();
	}
	
	public override void Update ()
	{
		float r = (float)this.elapsed / shoulderCycle;
		
		float sin = Mathf.Sin (r * Mathf.PI * 2);
		
		this.SetJointAngle (shoulderLeft, sin * this.shoulderAmplitude);
		this.SetJointAngle (shoulderRight, - sin * this.shoulderAmplitude);
		
		this.SetJointAngle (legLeft, sin * this.shoulderAmplitude);
		this.SetJointAngle (legRight, - sin * this.shoulderAmplitude);
		
		//float cos = Mathf.Cos( r * Mathf.PI * 2 * 2 );
		//this.SetPlayerYPos( cos * 0.1f );
		
		this.SwingHead (r);
		//
		base.Update ();
	}

	private void SwingHead (float r)
	{
		Vector3 angles = this.neck.localEulerAngles;
		angles.x = Mathf.Sin (r * Mathf.PI * 2) * this.neckAmplitude;
		//angles.y = Mathf.Sin ( r * Mathf.PI * 1 ) * this.neckAmplitude;
		angles.z = 0;
		this.neck.localEulerAngles = angles;
	}
	
}

public class JumpingAnimation : CharAnimation
{
	
	public JumpingAnimation (GameObject player) : base( player )
	{
	}
	
	public override void Start ()
	{
		this.SetSlidingPose (0);
		this.player.transform.localEulerAngles = new Vector3 (275, 90, 90); // lean character forward a little bit
		base.Start ();
		this.player.audio.Play ();
	}
	
	public override void Update ()
	{
		Vector3 pos = this.player.transform.position;
		float r = ((float)pos.y) / 12.0f;
		this.RotateHead (r);
		//
		base.Update ();
	}

}

public class SlidingAnimation : CharAnimation
{
	private int duration = 45;

	public SlidingAnimation (GameObject player) : base( player )
	{
	}

	public override void Start ()
	{
		base.Start ();
	}

	public override void Update ()
	{
		float n = ((float)this.elapsed / (float)this.duration);
		n = Mathf.Min (1, n);
		this.SetSlidingPose (n);
		base.Update ();
	}

}


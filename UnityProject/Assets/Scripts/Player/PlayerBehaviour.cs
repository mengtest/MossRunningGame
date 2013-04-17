using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
	public event CoinCollectedHandler coinCollected;

	private int totalCoins;
	public Vector2 velocity;
	public Vector2 gravity;
	private TreadmillBehaviour treadmill;

	public delegate void CoinCollectedHandler (int total_coins);

	private PlayerFSM fsm;

	void Start ()
	{
		this.totalCoins = 0;

		this.velocity = new Vector2 (0.15f, 0);
		this.gravity = new Vector2 (0, -0.01f);

		this.fsm = new PlayerFSM (this);
		this.fsm.start ();
	}

	void Update ()
	{
		this.fsm.Update ();
	}

	public void SetTreadmill(TreadmillBehaviour treadmill)
	{
		this.treadmill = treadmill;
	}
	public TreadmillBehaviour GetTreadmill()
	{
		return this.treadmill;
	}

	public void KillPlayer ()
	{
		Application.LoadLevel ("Menu");
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "crate") {
			//Debug.Log("oh! no! a crate!");
		}
		if (other.gameObject.tag == "coin") {
			this.totalCoins++;
			this.coinCollected (this.totalCoins);
		}
		if (other.gameObject.tag == "floorgap") {
			this.fsm.GoFalling ();
			float offset = other.gameObject.transform.localPosition.x - this.transform.localPosition.x;

			Debug.Log ("offset:" + offset);

			if (offset < 0) {
				this.velocity.x = 0.0f;
			}
		}
	}

}
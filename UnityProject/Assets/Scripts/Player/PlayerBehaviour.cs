using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
	public event CoinCollectedHandler coinCollected;

	private int totalCoins;
	public Vector2 velocity;
	public Vector2 gravity;


	public delegate void CoinCollectedHandler (int total_coins);

	private PlayerFSM fsm;

	void Start ()
	{
		this.totalCoins = 0;
		
		this.velocity = new Vector2 (0, 0);
		this.gravity = new Vector2 (0, -0.01f);

		this.fsm = new PlayerFSM (this);
		this.fsm.start ();
	}
	
	void Update ()
	{
		this.fsm.Update ();
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
	}

}
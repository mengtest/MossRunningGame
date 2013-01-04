using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	private CharAnimation loopedAnim;
	// Use this for initialization
	void Start () {
	
		this.loopedAnim = new RunningAnimation( this.gameObject ); 
		if(this.loopedAnim!=null) this.loopedAnim.Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.loopedAnim!=null) this.loopedAnim.Update();
	}
}

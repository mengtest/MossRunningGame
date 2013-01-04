using UnityEngine;
using System.Collections;

public class MenuMouseHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		if(this.name=="PlayButton") {
			Application.LoadLevel("Game");
			//Debug.Log("START");
		}
	}
}

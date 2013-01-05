using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {

	private TextMesh text;


	void Start () {
		this.text = this.GetComponent(typeof(TextMesh)) as TextMesh;
		this.text.text = "Score: " + SessionState.score.ToString();
	}

}

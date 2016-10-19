using UnityEngine;
using System.Collections;

public class GOScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Time.timeScale = 1;
			Application.LoadLevel (1);
		}
	}
}

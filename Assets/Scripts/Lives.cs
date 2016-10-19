using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public int lives;
	public GUIText Livestext;

	// Use this for initialization
	void Start () {
		lives = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Livestext.text = "Charge: +" + lives;
	}


}

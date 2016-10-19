using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

	public float distance;
	public GUIText distanceText;
	public GameObject Background;

	// Use this for initialization
	void Start () {
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		distance += Background.GetComponent<BG_Scroller> ().scrollSpeed / 10;
		distanceText.text = "Distance: " + Mathf.Floor(distance);
		Highscore.highScore += (int)distance;
	}


}

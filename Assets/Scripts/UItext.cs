using UnityEngine;
using System.Collections;

public class UItext : MonoBehaviour {

	public float distance;
	public int score;
	public GUIText distanceText;
	public GUIText scoreText;
	public GUIText hsText;
	public GameObject Background;
	
	// Use this for initialization
	void Start () {
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.timeScale == 1){
	
				distance += Background.GetComponent<BG_Scroller> ().scrollSpeed / 10;
		distanceText.text = "Distance: " + Mathf.Floor (distance);
		score = (int)Mathf.Pow (distance, 2.0F);
		scoreText.text = "Score: " + score;
		hsText.text = "High Score: " + Highscore.highScore;
//		print (Highscore.highScore);
		if (score >= Highscore.highScore) {
				Highscore.highScore = score;
		}
		
		}
	}
}

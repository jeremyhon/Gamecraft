using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	enum Mode {start, tutorial1, tutorial2};
	public GameObject tut1Sprite;
	public GameObject tut2Sprite;
	public GUIText spacebartext;
	Mode mode ;

	// Use this for initialization
	void Start () {
		mode = Mode.start;
		
		tut1Sprite.SetActive(false);
		tut2Sprite.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		print(mode);
		
		if(mode == Mode.tutorial2)
		{
			if(Input.GetKeyDown("space"))
			{
				Debug.Log(":LOLOL");
				Application.LoadLevel (1); 
				
			}	
			
		}
		else if(mode == Mode.tutorial1)
		{
			if(Input.GetKeyDown("space"))
			{
				mode = Mode.tutorial2;
				tut1Sprite.SetActive(false);
				tut2Sprite.SetActive(true);
			}	
			
		}
		else if(mode == Mode.start)
		{
			if(Input.GetKeyDown("space"))
			{
				mode = Mode.tutorial1;
				tut1Sprite.SetActive(true);
				tut2Sprite.SetActive(false);
				spacebartext.text = "";
			}	
			
		}
		

	}
}

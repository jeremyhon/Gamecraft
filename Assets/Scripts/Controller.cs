using UnityEngine;
using System.Collections;

// This code is for making the player move!
// If you attach this code to something, it will respond to your arrow keys and move.
// But it needs a rigidbody to work. So remember to attach one to the gameobject.


public class Controller : MonoBehaviour {

	// Use [SerializeField] or public to make the variable editable from the unity interface.
	[SerializeField]
	private float speed = 15f;

	public float moveTowardsSpeed = 5.0f;

	bool isBeingSuck = false;
	GameObject suckerObject;

	float startPosX;

	public GameObject repulseRadius;
	[System.NonSerialized]
	bool isRepulse = false;

	bool hasCharge = true;
	
	public GameObject defaultSprite;
	public GameObject glowSprite;	

	public GameObject GOScreen;

	public AudioClip[] audioClip ;




	void Start(){

		startPosX = this.transform.position.x;


	}

	// Update is called once every frame.
	void Update () {

		if(hasCharge){
			glowSprite.SetActive(true);
			defaultSprite.SetActive(false);
		}
		else
		{
			glowSprite.SetActive(false);
			defaultSprite.SetActive(true);
		}
		

		if (Input.GetKeyDown ("space") && hasCharge) {
						isRepulse = true;
						hasCharge = false;
		
				}

		if (Input.GetKeyUp ("space")) {
			isRepulse = false;
			}

		if (isRepulse)
						repulseRadius.SetActive (true);
				else
						repulseRadius.SetActive (false);

		// Movement controls.
		if (rigidbody2D != null) {
			Vector2 velocity = Vector2.zero; // a Vector2 has an x and y coordinate.
			
			if (Input.GetKey(KeyCode.UpArrow))
				velocity += Vector2.up*speed; // Vector2.up is defined as (0,1)
			
			if (Input.GetKey(KeyCode.DownArrow))
				velocity -= Vector2.up*speed;
			
			//if (Input.GetKey(KeyCode.LeftArrow))
			//	velocity -= Vector2.right*speed; // Vector2.right is defined as (1,0)
			
			//if (Input.GetKey(KeyCode.RightArrow))
			//	velocity += Vector2.right*speed;

			rigidbody2D.velocity  = velocity; // Update the rigidbody's velocity.


			if(isBeingSuck && suckerObject != null){

				transform.position = Vector3.MoveTowards(transform.position, suckerObject.transform.position, moveTowardsSpeed);

				transform.position = new Vector2(startPosX, transform.position.y);

			}
		}

	}
	
	public void GiveCharge(){
	     PlaySound(0); 
		 hasCharge = true;
	}

	public void MoveTowards(GameObject go){

		isBeingSuck = true;
		this.suckerObject = go;

	}

	public void StopSuck(){

		isBeingSuck = false;

	}
	
	void PlaySound (int clip){
		audio.clip = audioClip [clip]; 
		audio.Play(); 
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "wall") {
			if(isRepulse == false){
				PlaySound(1); 
				Time.timeScale = 0;
				GOScreen.SetActive (true);
				print("die");
				}
			}

		if (other.tag == "charge") {

			if(isRepulse == true){
				PlaySound(2); 
				other.GetComponent<Charge>().Repulse();
				
				}
			if(isRepulse == false){
				// pause level and show game over
				PlaySound(1); 
				Time.timeScale = 0;
				GOScreen.SetActive (true);
			}
		}
	}



}

using UnityEngine;
using System.Collections;

public class Outer : MonoBehaviour {

	GameObject charge;


	// Use this for initialization
	void Start () {
	
		//charge = this.GetComponent<Charge> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

				other.GetComponent<Controller>().MoveTowards(this.gameObject);


		}
	}


	void OnTriggerExit2D(Collider2D other) {

		if (other.tag == "Player") {

				other.GetComponent<Controller>().StopSuck();

		}
	}
}



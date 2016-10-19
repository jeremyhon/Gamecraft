using UnityEngine;
using System.Collections;

public class ChargeGate : MonoBehaviour {


	float Speed ;


	// Use this for initialization
	void Start () {
		Speed = GameObject.Find("Background").GetComponent<BG_Scroller>().scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (Speed, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Player") 
		{
			other.GetComponent<Controller>().GiveCharge();
		}
	}
}

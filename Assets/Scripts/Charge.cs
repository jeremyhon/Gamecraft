using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

	public float speedNeutron = 5.0f;
	public float speedProton = 5.0f;

	public enum Type {proton, neutron};

	Vector2 dir;	

	public Type type = Type.proton;

	GameObject player;

	float random ;

	// Use this for initialization
	void Start () {
			
		 random = Random.value;

		if (type == Type.proton) {
			if(random > 0.5f)
				dir = new Vector2 (-1, 1);
			else
				dir = new Vector2 (-1, -1);
				
		} else {
			dir = new Vector2 (-1, 0);
		}
		
		


		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (type == Type.proton)
			rigidbody2D.velocity = dir * speedProton ;
		else
			rigidbody2D.velocity = dir * speedNeutron ;

		//if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) > 0.01f) {
		//	print("nearrrr");
		//}
	}

	public void Repulse(){
		print ("repulse");

		if (type == Type.proton) {
			//dir = new Vector2 (1, 1);
			//dir = new Vector2 (-1, -1) * -1.0f;
			//dir = new Vector2(dir.x, dir.y) * -1.0f;
			if(random > 0.5f)
				dir = new Vector2 (1, 1) ;
			else
				dir = new Vector2 (1, -1) ;
		} else{
			if(this.transform.position.y - player.transform.position.y > 0)
				dir = new Vector2 (1, 1) ;
			else
				dir = new Vector2 (1, -1) ;

		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "wall") 
		{
			dir.y *= -1;
		}
	}
	
	
	


}

using UnityEngine;
using System.Collections;

public class TrailSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject prefab_trail;
	private Trail[] trails;
	[SerializeField]
	private GameObject source;
	
	private int nTrails = 40;
	private int current = 0;
	
	private float nextRecycle;
	private const float recycleTime = 0.05f;
	
	void Start() {
		trails = new Trail[nTrails];
		for (int i=0; i<nTrails; i++) {
			var trail = Instantiate(prefab_trail) as GameObject;
			trails[i] = trail.GetComponent<Trail>();
		}
		
		nextRecycle = Time.time;
		
	}
	
	void Update() {
		if (Time.time > nextRecycle) {
			RecycleTrail();
			nextRecycle += recycleTime;
		}
	}
	
	
	private void RecycleTrail() {
		trails[current].SpawnAt(source.transform.position);
		
		current++;
		if (current >= nTrails)
			current = 0;
	}
	
	
	
}

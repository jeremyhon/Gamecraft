using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Neutron;
	public GameObject Proton;
	public GameObject ChargeGate;
	int Spawntime =45;
	int Timer;
	int GateSpawntimer = 400;
	int GateTimer;
	// Use this for initialization
	void Start () {
		Timer = Spawntime;
		GateTimer = GateSpawntimer;
	}

	void SpawnNeutron() {
		Vector3 spawnPosition = new Vector3(10,Random.Range(-2,2),0);
		Instantiate(Neutron, spawnPosition, Quaternion.identity);
	}

	void SpawnProton() {
		Vector3 spawnPosition = new Vector3(10,Random.Range(-2,2),0);
		Instantiate(Proton, spawnPosition, Quaternion.identity);
	}

	void SpawnGate() {
		Vector3 spawnPosition = new Vector3(10,0,0);
		GameObject gate = Instantiate(ChargeGate, spawnPosition, Quaternion.identity) as GameObject;

		gate.transform.parent = GameObject.Find ("Background").transform;

	}

	void Update () {
		GameObject[] chargedparticles = GameObject.FindGameObjectsWithTag ("charge");
		Timer--;
		GateTimer--;
		if (Timer < 1) {
						Timer = Spawntime + (int)(Random.value*10);
						if (chargedparticles.Length < 10) {
								float random = Random.value;
								if (random > 0.5) {
										SpawnNeutron ();
								} else {
										SpawnProton ();
								}
						}
				}
		if (GateTimer < 1) {
						GateTimer = GateSpawntimer + (int)(Random.value * 10);
						SpawnGate ();
				}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject blocks;
	public GameObject powerUps;
	public float spawnTime;
	private int limit;
	private float currSpTime;


	// Use this for initialization
	void Start () {
		spawnTime = 3;
		limit = 10;
		currSpTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {

		currSpTime -= 1 * Time.deltaTime;

		if (currSpTime <= 0) {
			Spawn ();
			currSpTime = spawnTime;
		}

	}

	void Spawn(){

		GameObject toSpawnL = null;
		GameObject toSpawnR = null;

		if (Random.Range (0, 100) < 60) {
			toSpawnL = blocks;
		} else {
			toSpawnL = powerUps;	
		}

		if (Random.Range (0, 100) < 60) {
			toSpawnR = blocks;
		} else {
			toSpawnR = powerUps;	
		}

		Vector3 spaPosL = new Vector3 (this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
		Vector3 spaPosR = new Vector3 (this.transform.position.x + 5, this.transform.position.y, this.transform.position.z);
			
		Collider[] hitColliderL = Physics.OverlapBox (spaPosL, new Vector3(4,1,1.5f));
		Collider[] hitCollderR = Physics.OverlapBox (spaPosR,new Vector3(4,1,1.5f));

		Debug.Log (hitColliderL.Length);

		if (hitColliderL.Length == 1) {
			GameObject toInsL = Instantiate (toSpawnL, spaPosL, this.transform.rotation).gameObject;
			toInitialize (toInsL, 5.0f, spaPosL.x - 5, spaPosL.x, true);

		}

		if (hitCollderR.Length == 1) {
			GameObject toInsR = Instantiate (toSpawnR, spaPosR, this.transform.rotation).gameObject;
			toInitialize (toInsR, 5.0f, spaPosR.x, spaPosR.x + 5 , true);

		}

	}

	void assignSpawn(GameObject spL, GameObject spR){



	}

	void toInitialize(GameObject spawn, float speed, float negative, float positive, bool axis){
		spawn.AddComponent<SpawnMove> ().toMove = spawn;
		spawn.GetComponent<SpawnMove> ().speed = speed;
		spawn.GetComponent<SpawnMove> ().left = negative;
		spawn.GetComponent<SpawnMove> ().right = positive;

		if (axis) {
			spawn.GetComponent<SpawnMove> ().XAxis = true;
		} else {
			spawn.GetComponent<SpawnMove> ().ZAxis = true;
		}
		Destroy (spawn, 15);
	}

}

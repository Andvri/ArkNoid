using System.Collections;
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

		Vector3 spaPosL = new Vector3 (this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
		Vector3 spaPosR = new Vector3 (this.transform.position.x + 5, this.transform.position.y, this.transform.position.z);
			
		Collider[] hitColliderL = Physics.OverlapSphere (spaPosL, 0.5f);
		Collider[] hitCollderR = Physics.OverlapSphere (spaPosR, 0.5f);

		Debug.Log (hitColliderL.Length);

		if (hitColliderL.Length == 1) {
			GameObject toInsL = Instantiate (blocks, spaPosL, this.transform.rotation).gameObject;
			toInsL.AddComponent<SpawnMove> ().toMove = toInsL;
			toInsL.GetComponent<SpawnMove> ().speed = 5.0f;
			toInsL.GetComponent<SpawnMove> ().left = spaPosL.x-5;
			toInsL.GetComponent<SpawnMove> ().right = spaPosL.x;
			toInsL.GetComponent<SpawnMove> ().XAxis = true;
			Destroy (toInsL, Random.Range(7,10));
		}

		if (hitCollderR.Length == 1) {
			GameObject toInsR = Instantiate (blocks, spaPosR, this.transform.rotation).gameObject;
			toInsR.AddComponent<SpawnMove> ().toMove = toInsR;
			toInsR.GetComponent<SpawnMove> ().speed = 5.0f;
			toInsR.GetComponent<SpawnMove> ().left = spaPosR.x;
			toInsR.GetComponent<SpawnMove> ().right = spaPosR.x+5;
			toInsR.GetComponent<SpawnMove> ().XAxis = true;
			Destroy (toInsR, Random.Range(7,10));
		}

	}

}

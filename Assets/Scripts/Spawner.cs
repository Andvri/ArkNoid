using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject blocks;
	public GameObject powerUps;
	public float spawnTime;
	public int spawnMode;
	private float currSpTime;


	// Use this for initialization
	void Start () {
		spawnTime = 3;
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

		if (Random.Range (0, 100) < 80) {
			toSpawnL = blocks;
		} else {
			toSpawnL = powerUps;	
		}

		if (Random.Range (0, 100) < 80) {
			toSpawnR = blocks;
		} else {
			toSpawnR = powerUps;	
		}

		switch(spawnMode){

			case 0:
			{
				Vector3 spaPosL = new Vector3 (this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
				Vector3 spaPosR = new Vector3 (this.transform.position.x + 5, this.transform.position.y, this.transform.position.z);

				Collider[] hitColliderL = Physics.OverlapSphere(spaPosL, 2.5f);
				Collider[] hitColliderR = Physics.OverlapSphere(spaPosR, 2.5f);

				//Debug.Log (hitColliderL.Length);
				//Debug.Log (hitColliderR.Length);

				if (hitColliderL.Length <= 1 && hitColliderR.Length <= 1) {
					GameObject toInsL = Instantiate (toSpawnL, spaPosL, this.transform.rotation).gameObject;
					toInitialize (toInsL, 5.0f, spaPosL.x - 5, spaPosL.x, true, false);
					GameObject toInsR = Instantiate (toSpawnR, spaPosR, this.transform.rotation).gameObject;
					toInitialize (toInsR, 5.0f, spaPosR.x, spaPosR.x + 5 , true, false);
				}


				break;
			}

			case 1:
			{
				Vector3 spaPosL = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Vector3 spaPosR = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Collider[] hitColliderL = Physics.OverlapSphere(spaPosL, 2.0f);
				Collider[] hitColliderR = Physics.OverlapSphere(spaPosR,2.0f);

				//Debug.Log (hitColliderL.Length);

				if (hitColliderL.Length <= 1 && hitColliderR.Length <= 1) {
					GameObject toInsL = Instantiate (toSpawnL, spaPosL, this.transform.rotation).gameObject;
					toInitialize (toInsL, 5.0f, spaPosL.x - 5, spaPosL.x, true, true);
					GameObject toInsR = Instantiate (toSpawnR, spaPosR, this.transform.rotation).gameObject;
					toInitialize (toInsR, 5.0f, spaPosR.x, spaPosR.x + 5 , true, true);

				}


				break;
			}

		
		}

	}

	void toInitialize(GameObject spawn, float speed, float negative, float positive, bool axis, bool rotate){
		spawn.AddComponent<SpawnMove> ().toMove = spawn;
		spawn.GetComponent<SpawnMove> ().speed = speed;
		spawn.GetComponent<SpawnMove> ().left = negative;
		spawn.GetComponent<SpawnMove> ().right = positive;

		if (axis) {
			spawn.GetComponent<SpawnMove> ().XAxis = true;
		} else {
			spawn.GetComponent<SpawnMove> ().ZAxis = true;
		}

		if (rotate) {
			spawn.GetComponent<SpawnMove> ().rotate = true;
		}

		Destroy (spawn, 15);
	}

}

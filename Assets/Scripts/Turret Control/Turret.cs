using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret: MonoBehaviour {

	public GameObject turret;
	public RandomDirection targetRD;
	public SpawnMove targetSM;
	public GameObject laser;
	private float spawnTime;


	// Use this for initialization
	void Start () {
		spawnTime = Time.time + Random.Range(3,5);
	}
	
	// Update is called once per frame
	void Update () {		
		
		if (Time.time >= spawnTime) {

			if (targetRD && targetRD.move) {				
				targetRD.move = false;
				StartCoroutine( MoveTarget ());
				//Debug.Log (RandomDirection.move);
				GameObject toIns = (Instantiate (laser, turret.transform.position, turret.transform.rotation)).gameObject;
				toIns.SetActive(true);
				Destroy (toIns, 4.0f);
			}
			if (targetSM && targetSM.XAxis) {
				targetSM.XAxis = false;
				StartCoroutine( MoveTarget ());
				//Debug.Log (RandomDirection.move);
				GameObject toIns = (Instantiate (laser, turret.transform.position, turret.transform.rotation)).gameObject;
				toIns.SetActive(true);
				Destroy (toIns, 4.0f);

			}
			spawnTime = Time.time + Random.Range(3,5);
		}		

	}

	IEnumerator MoveTarget(){
		yield return new WaitForSeconds(Random.Range(3,5));
		if (targetRD && !targetRD.move) {
			targetRD.move = true;
		}
		if (targetSM && !targetSM.XAxis) {
			targetSM.XAxis = true;
		}
			
	}
}

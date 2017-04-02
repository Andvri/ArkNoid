using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret: MonoBehaviour {

	public GameObject turret;
	public RandomDirection target;
	public GameObject laser;
	private float spawnTime;


	// Use this for initialization
	void Start () {
		spawnTime = Time.time + Random.Range(3,5);
	}
	
	// Update is called once per frame
	void Update () {		
		
		if (Time.time >= spawnTime) {

			if (target.move) {
				target.move = false;
				StartCoroutine( MoveTarget ());
				//Debug.Log (RandomDirection.move);
				GameObject toIns = (Instantiate (laser, turret.transform.position, turret.transform.rotation)).gameObject;
				//toIns.SetActive(true);
			}
			spawnTime = Time.time + Random.Range(3,5);
		}		

	}

	IEnumerator MoveTarget(){
		yield return new WaitForSeconds(Random.Range(3,5));
		target.move = true;
			
	}
}

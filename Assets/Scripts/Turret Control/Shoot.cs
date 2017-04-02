using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject destination;
	Vector3 newPos;
	bool isLerping;
	bool deleted;
	// Use this for initialization
	void Start () {
		Vector3 aux = destination.transform.position;
		newPos = new Vector3(aux.x,aux.y,aux.z);
		isLerping = true;
		deleted = false;
	}

	void OnTriggerEnter(Collider col){

		//Debug.Log ("SPHEREHIT");
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player")){
			Debug.Log ("Ded");
		}

	}

	// Update is called once per frame
	void Update () {

		if (isLerping) {
			
			this.transform.position = Vector3.Lerp (this.transform.position, newPos, Time.deltaTime * 2.75f);
			//Debug.Log ("Still Lerping");
			if (Vector3.Distance(this.transform.position,newPos) <= 3f){
				isLerping = false;
				Debug.Log ("Stop Lerp");
			}

		} else {

			Vector3 aux = destination.transform.position;
			newPos = new Vector3 (aux.x, 90, aux.z);
			this.transform.position = Vector3.Lerp (this.transform.position, newPos, Time.deltaTime * 0.55f);

			if (this.transform.position.y >= 80f && !deleted) {
				deleted = true;
				Destroy (this.gameObject);
			}

		}
	}


}

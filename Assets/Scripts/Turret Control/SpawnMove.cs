using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour {


	public GameObject toMove;
	public float left;
	public float right;
	public float top;
	public float down;
	public float speed;
	public bool XAxis;
	public bool ZAxis;
	private bool up;
	private bool sides;

	// Use this for initialization
	void Start () {	
		up = true;
		sides = true;
	}


	// Update is called once per frame
	void Update () {

		if (ZAxis) {
			
			float Z; 

			if (up) {
				Z = toMove.transform.position.z + (Time.deltaTime * speed);
			} else {
				Z = toMove.transform.position.z + (Time.deltaTime * -speed);
				Debug.Log (Z);
			}

			if (toMove.transform.position.z == top) {
				up = false;
			} else if (toMove.transform.position.z == down) {
				up = true;
			}

			toMove.transform.position = new Vector3 (toMove.transform.position.x, toMove.transform.position.y, Mathf.Clamp (Z, down, top));
		}

		if (XAxis){
			
			float X; 

			if (sides) {
				X = toMove.transform.position.x + (Time.deltaTime * speed);
			} else {
				X = toMove.transform.position.x + (Time.deltaTime * -speed);
			}

			if (toMove.transform.position.x == right) {
				sides = false;
			} else if (toMove.transform.position.x == left) {
				sides = true;
			}

			toMove.transform.position = new Vector3 (Mathf.Clamp (X, left, right), toMove.transform.position.y, toMove.transform.position.z );
		}


	}
}

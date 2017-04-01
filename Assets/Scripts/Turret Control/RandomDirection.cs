using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour {

	public GameObject toMove;
	public float left;
	public float right;
	public float up;
	public float down;
	public float YLocation;
	Vector3 despl;
	public bool move;

	// Use this for initialization
	void Start () {	
		this.move = true;
		despl = toMove.transform.position;	
	}


	// Update is called once per frame
	void Update () {

		if (this.move) {
			float speed = 3.2f;	

			if (toMove.transform.position.x <= left) {
				despl = (new Vector3 (Random.Range (0f, 0.1f), 0, Random.Range (-0.1f, 0.1f)));

			}
			if (toMove.transform.position.x >= right) {
				despl = (new Vector3 (-Random.Range (0f, 0.1f), 0, Random.Range (-0.1f, 0.1f)));

			}
			if (toMove.transform.position.z <= down) {
				despl = (new Vector3 (Random.Range (-0.1f, 0.1f), 0, Random.Range (0f, 0.1f)));

			}
			if (toMove.transform.position.z >= up) {
				despl = (new Vector3 (Random.Range (-0.1f, 0.1f), 0, -Random.Range (0f, 0.1f)));

			}

			toMove.transform.position = new Vector3 (Mathf.Clamp (toMove.transform.position.x + (despl.x * speed), left, right), YLocation, Mathf.Clamp (toMove.transform.position.z + (despl.z * speed), down, up));
		}

	}
}

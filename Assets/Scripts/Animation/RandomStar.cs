using UnityEngine;
using System.Collections;

public class RandomStar : MonoBehaviour {
    public GameObject Stars;
    public Vector3 randomV3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        randomV3 = new Vector3(Random.Range(-30, 30), Random.Range(-15, -3),35);
        Instantiate(Stars, randomV3,transform.rotation);
	}
}

using UnityEngine;
using System.Collections;

public class StarMove : MonoBehaviour {
    private float MoveZ;
    private float DesTime=0;
	// Use this for initialization
	void Start () {
        MoveZ = Random.Range(-5, -20)*Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(0, 0, MoveZ);
        DesTime += Time.deltaTime;
        if (DesTime > 2)
        {
            Destroy(this.gameObject);
        }
	}
}

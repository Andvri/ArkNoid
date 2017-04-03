﻿using UnityEngine;
using System.Collections;

public class PowerHealth : MonoBehaviour {
	
    public int PowerHealt;
    public int Point1;
    public int PointDes;

	// Use this for initialization
	void Start () {
        PointDes = Point1 * PowerHealt;
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        PowerHealt--;
        if (PowerHealt == 0)
        {
            Destroy(gameObject);
            (GameObject.FindWithTag("GameController").GetComponent<Score>()).increase(PointDes);
		
            return;
        }
        (GameObject.FindWithTag("GameController").GetComponent<Score>()).increase(Point1);
        
    }

}

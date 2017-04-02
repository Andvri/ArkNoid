using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        GameObject[] vDestructibleEntity = GameObject.FindGameObjectsWithTag("Destructible Entity");
        if (vDestructibleEntity.Length == 0)
            Time.timeScale = 0;

    }
}

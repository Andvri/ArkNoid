using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSelf_destruct : MonoBehaviour {
    public float time;
    // Use this for initialization


    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        if (time <= 0)
            Destroy(gameObject);
	}
}

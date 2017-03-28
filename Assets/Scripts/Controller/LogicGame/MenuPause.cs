using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {
    public GameObject menupause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)){
            Debug.Log("Entro en escape");
            menupause.SetActive(true);
        }
	}
}

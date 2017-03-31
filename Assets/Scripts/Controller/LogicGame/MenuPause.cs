using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {
    public GameObject menupause;
    public bool band;
	// Use this for initialization
	void Start () {
        band = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape) && !band){

            Debug.Log("Entro en escape");
            menupause.SetActive(true);
            Time.timeScale = 0;
            band = !band;
            return;
        }
        if (Input.GetKey(KeyCode.Escape) && band)
        {

            Debug.Log("Entro en escape");
            menupause.SetActive(false);
            Time.timeScale = 1;
            band = !band;
            return;
        }

    }
}

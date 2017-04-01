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
        if (Input.GetKey(KeyCode.Escape)){
            MP();
             
        }
        

    }
    public void MP()
    {
        if (band)
        {
            menupause.SetActive(false);
            Time.timeScale = 1;
            band = !band;
        }
        else
        {
            menupause.SetActive(true);
            Time.timeScale = 0;
            band = !band;
        }
    }
}

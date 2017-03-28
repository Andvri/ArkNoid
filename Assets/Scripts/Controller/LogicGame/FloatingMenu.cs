using UnityEngine;
using System.Collections;

public class FloatingMenu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject credits;
    



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void starPlayMenu()
    {
        playMenu.SetActive(true);
    }
    public void exitPlayMenu()
    {
        playMenu.SetActive(false);
    }
    public void starArcadeMode()
    {
        //cambiar a scene1
    }
    public void starCreditsMenu()
    {
        credits.SetActive(true);
    }
    public void exitCreditsMenu()
    {
        credits.SetActive(false);
    } 


}

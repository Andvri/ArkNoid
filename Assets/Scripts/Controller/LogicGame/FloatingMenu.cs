using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class FloatingMenu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject credits;
    public GameObject Records;
    public Text RecordText;



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
    
    public void starRecords()
    {
        Records.SetActive(true);
        UpdateRecords();
    }
    public void exitRecords()
    {
        Records.SetActive(false);
    }

    public void UpdateRecords()
    {
        GameObject Data = GameObject.FindGameObjectWithTag("Persisteng");
        List<int> lscores = new List<int>();
        lscores =Data.GetComponent<SaveLoad>().scores;
        List<string> ltimes = new List<string>();
        ltimes = Data.GetComponent<SaveLoad>().times;
        string nuevoText = "Level\tTime\tScore\n";
        RecordText.text = nuevoText;
        for (int i = 0; i < 10; i++)
        {
            nuevoText += ((i+1)+")\t"+ltimes[i]+"\t"+lscores[i]+"\n");
        }
        RecordText.text = nuevoText;
        Debug.Log(nuevoText);
    }

}

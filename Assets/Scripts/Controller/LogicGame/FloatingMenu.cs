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
    public GameObject SeleccionLevel;
    public GameObject FloatingSelectLevel;
    public Text RecordText;
    public Dropdown Drow;


	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().Vidas = 100;
        GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SelectionLevel = false;

        if (GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().Exist())
        {
            List<string> opc = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                if (GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().times[i] != "00:00:00")
                    opc.Add((i + 1).ToString());
            }
            Drow.AddOptions(opc);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().times[0] != "00:00:00")
        {
            SeleccionLevel.SetActive(true);
            
        }
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
    public void exitSelectLevel() {
        FloatingSelectLevel.SetActive(false);
    } 
    public void starSelectLevel()
    {
        FloatingSelectLevel.SetActive(true);
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
        nuevoText += "Survival\nTime\tScore\n";
        nuevoText += (ltimes[10] + "\t" + lscores[10] + "\n");
        RecordText.text = nuevoText;
        Debug.Log(nuevoText);
    }

}

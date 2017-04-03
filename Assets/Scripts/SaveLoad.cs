using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
    public static SaveLoad saveload;
    public List<string> times;
    public List<int> scores;
    

    public string pathArcade;
    // Use this for initialization
    private void Awake()
    {   if(saveload == null)
        {
            saveload = this;
            DontDestroyOnLoad(gameObject);
        }else if( saveload != this){
            Destroy(gameObject);
            
        }
        
        pathArcade = Application.persistentDataPath + "/ArcadeData.dat";
        Debug.Log(pathArcade);
    }
    void Start () {
        Load();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Load()
    {
        if (File.Exists(pathArcade))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(pathArcade, FileMode.Open);

            Arcade_Data dataA = (Arcade_Data)bf.Deserialize(file);
            times = dataA.Times;
            scores = dataA.Scores;
            file.Close();

        }else
        {
            scores.Add(0);

            for (int i = 0; i < 10; i++)
            {
                times.Add("00:00:00");
                scores.Add(0);
            }
            
            
        }
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(pathArcade);
        
        Arcade_Data dataA = new Arcade_Data();
        dataA.Times = times;
        dataA.Scores = scores;
        bf.Serialize(file,dataA);
        file.Dispose();
        file.Close();

    }
}


[Serializable]
class Arcade_Data {
  
    public List<string> Times;
    
    public List<int> Scores;


    public Arcade_Data() {
        Times = new List<string>();
        Scores = new List<int>();
        

        for (int i = 0; i < 10; i++)
        {
           this.Times.Add("00:00:00");
            Scores.Add(0);
        }
        Scores.Add(0);
    }

    //TimeRecord1 = TimeRecord2 = TimeRecord3 = TimeRecord4 = TimeRecord5 = TimeRecord6 = "00:00:00";
    //TimeRecord7 = TimeRecord8 = TimeRecord9 = TimeRecord10 = "00:00:00";
    //ScoreMax1 = ScoreMax2 = ScoreMax3 = ScoreMax4 = ScoreMax5 = ScoreMax6 = ScoreMax7 = 0;
    // ScoreMax8 = ScoreMax9 = ScoreMax10 = ScoreMaxArcadeMode =0;
    /*
  public string TimeRecord1;
  public string TimeRecord2;
  public string TimeRecord3;
  public string TimeRecord4;
  public string TimeRecord5;
  public string TimeRecord6;
  public string TimeRecord7;
  public string TimeRecord8;
  public string TimeRecord9;
  public string TimeRecord10;

  public int ScoreMax1;
  public int ScoreMax2;
  public int ScoreMax3;
  public int ScoreMax4;
  public int ScoreMax5;
  public int ScoreMax6;
  public int ScoreMax7;
  public int ScoreMax8;
  public int ScoreMax9;
  public int ScoreMax10;
  public int ScoreMaxArcadeMode;
  */

};

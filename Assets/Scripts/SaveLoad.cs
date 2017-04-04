using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
    public bool SelectionLevel;
    public string SceneToLoad;
    public int Vidas;
    public static SaveLoad saveload;
    public List<string> times;
    public List<int> scores;
    public string pathArcade;
    [Header("Sounds")]
    public AudioSource MissionComplete;
    public AudioSource Death;
    // Use this for initialization
    private void Awake()
    {

        times = new List<string>();
        scores = new List<int>();
        if (saveload == null)
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
        SceneToLoad = "MainScene";
        Load();

	}
    public int GetVidas()
    {
        return (SelectionLevel) ? 10 : Vidas;
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
            

            for (int i = 0; i < 11; i++)
            {
                times.Add("00:00:00");
                scores.Add(0);
            }
            
            
        }
        
    }
    public bool Exist()
    {
        return File.Exists(pathArcade);
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
    public void MissionCompletePlay()
    {
        MissionComplete.Play();
    }
    public void DeathPlay()
    {
        Death.Play();
    }
}


[Serializable]
class Arcade_Data {
    public List<string> Times;
    public List<int> Scores;
    public Arcade_Data() {
        Times = new List<string>();
        Scores = new List<int>();
        for (int i = 0; i < 11; i++)
        {
           this.Times.Add("00:00:00");
            Scores.Add(0);
        }
       
    }
};

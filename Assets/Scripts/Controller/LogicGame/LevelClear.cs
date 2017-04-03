using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelClear : MonoBehaviour {
    public GameObject ClearMenu;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        GameObject[] vDestructibleEntity = GameObject.FindGameObjectsWithTag("Destructible Entity");
        if (vDestructibleEntity.Length == 0)
        {
            //Time.timeScale = 0;
            ClearMenu.SetActive(true);
            string name = SceneManager.GetActiveScene().name;
            int pos = int.Parse(name)-1;
            GameObject Indestructible = GameObject.FindGameObjectWithTag("Persisteng");
            GameObject GameMaster = GameObject.FindGameObjectWithTag("GameController");
            GameObject Tempo = GameObject.FindGameObjectWithTag("Timer");
            Indestructible.GetComponent<SaveLoad>().scores[pos] = GameMaster.GetComponent<Score>().points();
            
            if (BestTime(Indestructible.GetComponent<SaveLoad>().times[pos], Tempo.GetComponent<Timer>().TiempoS()))
            {
                Indestructible.GetComponent<SaveLoad>().times[pos] = Tempo.GetComponent<Timer>().TiempoS();
            }
            
            Indestructible.GetComponent<SaveLoad>().Save();

        }
            

    }
    public bool BestTime(string Actual, string Nuevo)
    {
        string[] splitA = Actual.Split(':');
        string[] splitB = Nuevo.Split(':');
        if ((int.Parse(splitA[0]) == 0) && (int.Parse(splitA[1]) == 0) && (int.Parse(splitA[2]) == 0))// si es primera vez
        {
            return true;
        }
            
        if (int.Parse(splitB[0]) > int.Parse(splitA[0]))
        {
            return false;
        }

        if (int.Parse(splitB[1]) > int.Parse(splitA[1]))
        {
            return false;
        }
        if (int.Parse(splitB[2]) > int.Parse(splitA[2]))
        {
            return false;
        }

        return true;
    }

    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
       
    }
    public void  puntosGuardar()
    {

    }


}

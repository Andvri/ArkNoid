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
            Time.timeScale = 0;
            ClearMenu.SetActive(true);

        }
            

    }

    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
       
    }


}

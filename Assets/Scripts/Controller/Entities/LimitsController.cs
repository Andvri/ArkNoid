﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LimitsController : MonoBehaviour {
    public GameObject Louse;
    public GameObject Help;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Se llama a OnTriggerExit cuando el colisionador other deja de tocar el disparador
    private void OnTriggerExit(Collider other)
    {
       
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
            if (balls.Length == 1)
            {
                TableController table = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TableController>();
                
                table.Reset();
                if (SceneManager.GetActiveScene().name != "StoryMode") {
                    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().vidas == 0)
                    {
                        Louse.SetActive(true);
                        Destroy(Help);
                    }  
                    else
                    {
                        GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().Vidas--;
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().vidas--;
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().updateScore();
                    }
                    
                }
            }

        }
        if (other.gameObject.CompareTag("Beam") || other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
        
    }


}

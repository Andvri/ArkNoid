﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
    public string SceneName;
    public float time;

    public void Awake()
    {
        SceneName = "Level1";
        time = 0.5f;
    }
    // Use this for initialization
    void Start () {
	
	}
    [ContextMenu("Cargar Scene")]
    public void cargarScene()
    {
        Invoke("_ChangeScene", time);
    }

    public void _ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Sali de la app");
    }
}

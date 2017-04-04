﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public Text score;
    public int  puntos;
    public int vidas;
    public string nue;
    // Use this for initialization
    void Start()
    {
        vidas = GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().GetVidas();
        if (vidas == 0)
        {
            GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().Vidas = 10;
            vidas = 10;
        }
        puntos = 0;
         nue = "Score: " + puntos.ToString() + "\n♥x" + vidas.ToString();
        score.text = nue ;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void increase(int n)
    {
        puntos += n;
        updateScore();
        
    }
    public void updateScore()
    {
         nue = "Score: " + puntos.ToString() + "\n♥x" + vidas.ToString();
        score.text = nue;
    }
    public string cad()
    {
        return nue;
    }
    public int points()
    {
        return puntos;
    }
    
}

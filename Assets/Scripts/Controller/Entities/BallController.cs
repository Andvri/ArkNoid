﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public Vector3 ResetPosition;
    public GameObject angle;
    public touch sta;
    private Transform parent;
    public TableController controllerparent;
    // Use this for initialization
    private void Awake()
    {
        
        parent = transform.parent;
       
    }
    void Start () {
        ResetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Reset")]
    public void Reset()
    {
        parent.transform.localScale = Vector3.one;
        transform.localScale = Vector3.one;
        controllerparent.Reset();
        transform.SetParent(parent);
        transform.position = ResetPosition;
        Rigidbody ball = GetComponent<Rigidbody>();
        ball.velocity = Vector3.zero;
        angle.SetActive(true);
        sta.play = false;
    }

    // Se llama a OnCollisionEnter cuando este colisionador o cuerpo rígido comienza a tocar a otro cuerpo rígido o colisionador
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Respawn")){
            GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity*1.2f,30);
        //}
            
    }


}

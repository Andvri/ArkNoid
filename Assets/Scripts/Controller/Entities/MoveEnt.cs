using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnt : MonoBehaviour {
    public Vector3 Direccion;
    private int ida;
    public int Desplazamiento;
	// Use this for initialization
	void Start () {
        Desplazamiento *= 10;
        ida = Desplazamiento;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_ori = transform.position;

        if(ida > 0){
            transform.position = pos_ori +(Direccion*Time.deltaTime);
        }
        if (ida <= 0)
        {
            transform.position = pos_ori - (Direccion * Time.deltaTime);


            
        }
        ida--;
        if (ida <= -Desplazamiento)
            ida = Desplazamiento;

    }
}

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
<<<<<<< HEAD
        if(ida > 0){
            transform.position = pos_ori +(Direccion*Time.deltaTime);
        }
        if(ida <= 0){
            transform.position = pos_ori - (Direccion * Time.deltaTime);
=======
        if (ida >0){
            
            transform.position = pos_ori +(Direccion*Time.deltaTime * 0.05f);
            
        }
        if (ida <= 0){
            transform.position = pos_ori - (Direccion * Time.deltaTime * 0.08f);
<<<<<<< HEAD
>>>>>>> origin/master
=======
>>>>>>> origin/master
        }
        ida--;
        if (ida <= -Desplazamiento)
            ida = Desplazamiento;

    }
}

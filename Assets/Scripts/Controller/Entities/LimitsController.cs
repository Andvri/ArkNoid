using UnityEngine;
using System.Collections;

public class LimitsController : MonoBehaviour {

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
            }

        }
        if (other.gameObject.CompareTag("Beam") || other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
        
    }


}

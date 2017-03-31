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
        Debug.Log("Salio");
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
            if (balls.Length == 1)
            {
                TableController table = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TableController>();
                Debug.Log("Entro al if");
                table.Reset();
            }

        }
        if (other.gameObject.CompareTag("Beam"))
        {
            Destroy(other.gameObject);
        }
        
    }


}

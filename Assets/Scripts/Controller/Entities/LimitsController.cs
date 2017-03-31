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
            BallController cB = other.gameObject.GetComponent<BallController>();
            cB.Reset();
        }
        
    }


}

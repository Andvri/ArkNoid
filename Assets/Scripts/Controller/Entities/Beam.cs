using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
      
	// Update is called once per frame
	void Update () {
	
	}

    // Se llama a OnTriggerEnter cuando el colisionador other escribe en el disparador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
			if (GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ()) {
				GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ().DecreaseHealth ();
			}
			
            other.gameObject.GetComponent<TableController>().Reset();
        }
    }
    [ContextMenu("Booms")]
    public void Boom()
    {   
        GetComponent<Rigidbody>().AddForce(Vector3.forward* -1000);
        transform.SetParent(null);
    }

}

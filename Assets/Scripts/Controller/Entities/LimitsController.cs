using UnityEngine;
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

			if (GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ()) {
				GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ().DecreaseHealth ();
			}

            if (balls.Length == 1)
            {
                TableController table = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TableController>();
				if (SceneManager.GetActiveScene ().name != "Testing") {
					GameObject.FindGameObjectWithTag ("Persisteng").GetComponent<SaveLoad> ().DeathPlay ();
				}
                table.Reset();
                if (SceneManager.GetActiveScene().name != "Testing") {
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

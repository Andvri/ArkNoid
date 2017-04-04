using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LimitsController : MonoBehaviour {
    public GameObject Louse;
    public GameObject Help;
<<<<<<< HEAD
    public float time;
=======

>>>>>>> origin/master
	// Use this for initialization
	void Start () {
        time = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            ResetTable();
            time = 1f;
        }
	}

    // Se llama a OnTriggerExit cuando el colisionador other deja de tocar el disparador
    private void OnTriggerExit(Collider other)
    {
       
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            
			GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
<<<<<<< HEAD

			if (GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ()) {
				GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ().DecreaseHealth ();
			}

            if (balls.Length == 0)
=======
		
            if (balls.Length == 1)
>>>>>>> origin/master
            {
				if (GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ()) {
					GameObject.FindGameObjectWithTag ("Respawn").GetComponent<PHealthStory> ().DecreaseHealth ();
				}
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
    private void ResetTable()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
        if (balls.Length == 0)
        {
            TableController table = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TableController>();
            if (SceneManager.GetActiveScene().name != "Testing")
            {
                GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().DeathPlay();
            }
            table.Reset2();
            if (SceneManager.GetActiveScene().name != "Testing")
            {
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


}

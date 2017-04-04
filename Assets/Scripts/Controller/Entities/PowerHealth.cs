using UnityEngine;
using System.Collections;

public class PowerHealth : MonoBehaviour {
	
    public int PowerHealt;
    public int Point1;
    public int PointDes;
    public AudioSource Sound;
    [Header("Explosion Particle")]
    public GameObject Explo;
	// Use this for initialization
	void Start () {
        PointDes = Point1 * PowerHealt;
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        PowerHealt--;
        if(Sound != null)
        {
            Debug.Log("Orale Guerito");
            Sound.Play();
        }
        if (PowerHealt == 0)
        {
            
            if (Explo != null)
            {
                var al=Instantiate(Explo);
                al.transform.position = transform.position;
                
            }
            Destroy(gameObject);
            (GameObject.FindWithTag("GameController").GetComponent<Score>()).increase(PointDes);
		
            return;
        }
        (GameObject.FindWithTag("GameController").GetComponent<Score>()).increase(Point1);
        
    }

}

using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(gameObject);
            GameObject []balls = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < balls.Length; i++)
            {
                Multiplicar(balls[i]);
               
            }
               
        }
       
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Multiplicar(GameObject ball) {
        ball.transform.localScale *= (9f/10f);
        GameObject clone1 = Instantiate(ball);
        clone1.GetComponent<Rigidbody>().AddForce(ball.GetComponent<Rigidbody>().velocity);
        GameObject clone2 = Instantiate(ball);

        clone2.GetComponent<Rigidbody>().AddForce(ball.GetComponent<Rigidbody>().velocity);

    }
}

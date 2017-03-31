using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {

            ReScaleTable(0.8f);
        }
       
    }

    private void Pow()
    {
        
         GameObject []balls = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < balls.Length; i++)
        {
            Multiplicar(balls[i]);

         }
    }
    private void Multiplicar(GameObject ball) {
        ball.transform.localScale *= (9f/10f);
        GameObject clone1 = Instantiate(ball);
        clone1.GetComponent<Rigidbody>().AddForce(ball.GetComponent<Rigidbody>().velocity);
        GameObject clone2 = Instantiate(ball);

        clone2.GetComponent<Rigidbody>().AddForce(ball.GetComponent<Rigidbody>().velocity);

    }
    private void ReScaleTable(float ReScale=1.2f)
    {
        Vector3 escale = (GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().localScale);
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().localScale = new Vector3(escale.x *= ReScale, escale.y, escale.z);
        Vector3 escale2 = GameObject.Find("Player").GetComponent<Transform>().localScale;
        GameObject.Find("Player").GetComponent<Transform>().localScale = new Vector3(escale2.x / ReScale, escale2.y, escale2.z);


    }

}

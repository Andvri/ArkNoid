using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    public static float ReScalePlus = 1.2f ;
    public static float ReScaleMinus = 0.8f;
    public static int BallsM = 3;
    public float selector;
    private void Star()
    {
        selector = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject == GameObject.FindGameObjectWithTag("Respawn") || other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            selector = Random.Range(0f, 1f);
            
             if (selector>=0.3 && selector < 0.5)
            {
                ReScaleTable(Test.ReScalePlus);
            }
            if (selector >= 0.5 && selector < 0.7)
            {
                ReScaleTable(Test.ReScaleMinus);
            }
            
            if ((selector >= 0 && selector < 0.3))
            {
                if(GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play)
                {
                    Pow();
                }
            }
            if ((selector >= 0.7 && selector < 0.85))
            {
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play)
                {
                    ReScaleBall(Test.ReScalePlus, Test.ReScaleMinus);
                }
            }
            if ((selector >= 0.85 && selector <= 1))
            {
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play)
                {
                    ReScaleBall(Test.ReScaleMinus, Test.ReScalePlus);
                }
            }



            Destroy(gameObject);
        }
       
    }

    /*
     Posibilidades:
     [0-1].
     [0-0.1) Multiplicador Pelotas
     [0.1-0.15) Balas / cohetes [0.15-0.2)
     [0.2-0.4) Ampliacion Tabla/ Reduccion Tabla [0.4-0.6)
     [0.4-0.6) Velocidad+/ Velocidad- [0.6-0.8)    
     [0.8-0.9) Bola Hierro/ Multiplicador de puntos   [0.9-1]   
     */

    private void Pow()
    {
        
         GameObject []balls = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < balls.Length; i++)
        {
            Multiplicar(balls[i]);

         }
    }

    private void SpeedBall()
    {

    }
    private void Multiplicar(GameObject ball) {
       ball.transform.localScale *= (9f/10f);
        GameObject clone1 = Instantiate(ball);
        clone1.GetComponent<Rigidbody>().velocity =ball.GetComponent<Rigidbody>().velocity;
        GameObject clone2 = Instantiate(ball);
        clone2.GetComponent<Rigidbody>().velocity = -ball.GetComponent<Rigidbody>().velocity;
        //  GameObject clone2 = Instantiate(ball);

        //   clone2.GetComponent<Rigidbody>().AddForce(ball.GetComponent<Rigidbody>().velocity);

    }
    private void ReScaleTable(float ReScale)
    {
        Vector3 escale = (GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().localScale);
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().localScale = new Vector3(escale.x *= ReScale, escale.y, escale.z);
        //innecesario ya que nunca tendra la pelota agarrada mientras le cae el poder pòr que tiene que lanzarlo pero uehh nunca se sabe
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play == false)
        {
            Vector3 escale2 = GameObject.Find("Player").GetComponent<Transform>().localScale;
            GameObject.Find("Player").GetComponent<Transform>().localScale = new Vector3(escale2.x / ReScale, escale2.y, escale2.z);

        }


    }
    private void ReScaleBall(float ReScale,float Velocity)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
        foreach (var ball in balls)
        {
            ball.transform.localScale *= ReScale;
            ball.GetComponent<Rigidbody>().velocity *= Velocity;
        }
        
    }



}

using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {
    public GameObject tabla;
    public Transform cilindro;
    public Vector3 rotationg;
    public float angulo;
    public float LimitA;
    public float Velocit;
    public Rigidbody CRPelota;

    // Use this for initialization
    void Start () {
        Velocit = 300f;
        LimitA = 0.6f;
        rotationg = Vector3.zero;
        angulo = 0;
    }

 
    // Update is called once per frame
    void Update () {
     
        foreach (var touchactual in Input.touches)
        {
            if(touchactual.tapCount == 2)
            {
                float ang = (((cilindro.rotation.y * 100) *Mathf.PI)/180f);
                Vector3 force = new Vector3(Velocit*Mathf.Sin(ang), 0,Velocit*Mathf.Cos(ang));
                CRPelota.AddForce(force);
                break;
            }
           
            if (touchactual.phase == TouchPhase.Began)
            {
                
            }
            if (touchactual.phase == TouchPhase.Moved)
            {

                float moveH = touchactual.deltaPosition.x;
                Transform moveOb = tabla.GetComponent<Transform>();
                float newX = (moveH * Time.deltaTime * 3) + moveOb.position.x;
                moveOb.transform.position = new Vector3(Mathf.Clamp(newX, -5, 5), moveOb.transform.position.y, moveOb.transform.position.z);

                break;
            }
            if (touchactual.phase == TouchPhase.Stationary)
            {
                rotationg = new Vector3(0, touchactual.position.x, touchactual.position.y);
                angulo = Vector3.Angle(rotationg, Vector3.forward);
                cilindro.Rotate(Vector3.up, (angulo - 30)/10);
                if( cilindro.rotation.y > LimitA)
                {
                    cilindro.Rotate(Vector3.up, 100*(LimitA - cilindro.rotation.y));
                }
                if(cilindro.rotation.y < -LimitA)
                {
                    cilindro.Rotate(Vector3.up, -100 * (LimitA +cilindro.rotation.y));
                }
                break;
            }
            
            
             
        }

	
	}

}

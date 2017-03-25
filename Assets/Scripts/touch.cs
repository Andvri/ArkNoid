using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {
    public GameObject tabla;
    public Transform cilindro;
    public Vector2 origin;
    public Vector2 end;
    public Vector3 rotationg;
    public float angulo;
    public Color color;
    public Rigidbody CRPelota;

    // Use this for initialization
    void Start () {
        color = Color.white;
        origin = end = new Vector2( Screen.height / 2, Screen.width/2 );
        rotationg = Vector3.zero;
        angulo = 0;
    }

 
    // Update is called once per frame
    void Update () {
      //  Debug.Log(" Height: " + Screen.height + " Width: " + Screen.width);
        foreach (var touchactual in Input.touches)
        {
            if(touchactual.tapCount == 2)
            {
                Debug.Log("fUEGO");
                Debug.Log("Rotacion de la pelota"+cilindro.rotation);
                
                CRPelota.AddForce(new Vector3(100*cilindro.rotation.y,0,60));
            }
           
           // Debug.Log(" PHeight: " + touchactual.position.x + " PWidth: " + touchactual.position.y);
            if (touchactual.phase == TouchPhase.Began)
            {
              //  rotationg = new Vector3(0, touchactual.position.x, touchactual.position.y);
              //  angulo = Vector3.Angle(rotationg, Vector3.forward);
              //  cilindro.Rotate(Vector3.up,angulo-30);    
            }

            if (touchactual.phase == TouchPhase.Stationary)
            {
                rotationg = new Vector3(0, touchactual.position.x, touchactual.position.y);
                angulo = Vector3.Angle(rotationg, Vector3.forward);
                cilindro.Rotate(Vector3.up, (angulo - 30)/10);
                //Debug.Log(cilindro.rotation.y);
                if( cilindro.rotation.y > 0.6)
                {
                    cilindro.Rotate(Vector3.up, 100*(0.6f - cilindro.rotation.y));
                }
                if(cilindro.rotation.y < -0.6f)
                {
                    cilindro.Rotate(Vector3.up, -100 * (0.6f +cilindro.rotation.y));
                }

            }
            
            if (touchactual.phase == TouchPhase.Moved)
            {
                
                float moveH = touchactual.deltaPosition.x;
                Transform moveOb = tabla.GetComponent<Transform>();
                float newX = (moveH * Time.deltaTime * 3) + moveOb.position.x;
                moveOb.transform.position = new Vector3(Mathf.Clamp(newX, -5, 5), moveOb.transform.position.y, moveOb.transform.position.z);

                
            }  
             
        }

	
	}

}

using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {
	
	public GameObject table;


    private GameObject ball;
	public bool play;

    // Use this for initialization
    void Start () {
		
		play = false;
    }

 
    // Update is called once per frame
    void Update () {
     
        foreach (var touchactual in Input.touches)
        {
            if(touchactual.tapCount == 2)
            {


				if (!play && ball) {
                    ball = GameObject.FindGameObjectWithTag("Player");
					Debug.Log ("Detected");
					GameObject.FindGameObjectWithTag("Angle").SetActive(false);
					ball.transform.parent = null;

					Rigidbody BallRB = ball.GetComponent<Rigidbody> ();
					Vector3 newF = Vector3.ClampMagnitude(ball.transform.forward * 1250 * Time.deltaTime,30);
					BallRB.velocity = newF;
					play = true;
				}
				break;
            }
           
            if (touchactual.phase == TouchPhase.Began)
            {
                
            }
            if (touchactual.phase == TouchPhase.Moved)
            {

                float moveH = touchactual.deltaPosition.x;
                Transform moveOb = table.GetComponent<Transform>();
                float newX = (moveH * Time.deltaTime * 3) + moveOb.position.x;
                moveOb.transform.position = new Vector3(Mathf.Clamp(newX,-12.5f,12.5f), moveOb.transform.position.y, moveOb.transform.position.z);

                break;
            }
            if (touchactual.phase == TouchPhase.Stationary)
            {
                ball = GameObject.FindGameObjectWithTag("Player");
                Vector2 touchPosition = touchactual.position;
				double halfScreen = Screen.width / 2.0;
				Vector3 temp;
				

				//Debug.Log (ball.transform.eulerAngles.y);
				if(touchPosition.x < halfScreen && ball){									
					ball.transform.Rotate (Vector3.down * 80 * Time.deltaTime);	
					if (280 > ball.transform.eulerAngles.y && !(ball.transform.eulerAngles.y >= 0 && ball.transform.eulerAngles.y <= 80)) {
						temp = ball.transform.eulerAngles;
						temp.y = 280;
						ball.transform.eulerAngles = temp;
					}

				} else if (touchPosition.x > halfScreen && ball) {					
					ball.transform.Rotate (Vector3.up * 80 * Time.deltaTime);	
					if (80 < ball.transform.eulerAngles.y && !(ball.transform.eulerAngles.y >= 280 && ball.transform.eulerAngles.y <= 360) ) {
						temp = ball.transform.eulerAngles;
						temp.y = 80;
						ball.transform.eulerAngles = temp;
					}
				}

			

                break;
            }
            
            
             
        }

	
	}




}

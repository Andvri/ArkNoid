using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {
	
	public GameObject table;
	private GameObject ball;

    // Use this for initialization
    void Start () {
		ball = GameObject.Find ("Ball");
    }

 
    // Update is called once per frame
    void Update () {
     
        foreach (var touchactual in Input.touches)
        {
            if(touchactual.tapCount == 2)
            {
				
				GameObject angle = GameObject.Find ("Angle");
				Destroy (angle);
				ball.transform.parent = null;

				Rigidbody BallRB = ball.GetComponent<Rigidbody> ();
				Vector3 newF = ball.transform.forward * 1250 * Time.deltaTime;
				BallRB.velocity = newF;
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
                moveOb.transform.position = new Vector3(Mathf.Clamp(newX, -9.4f, 9.4f), moveOb.transform.position.y, moveOb.transform.position.z);

                break;
            }
            if (touchactual.phase == TouchPhase.Stationary)
            {
				Vector2 touchPosition = touchactual.position;
				double halfScreen = Screen.width / 2.0;
				Vector3 temp;
				float currVal;

				Debug.Log (ball.transform.eulerAngles.y);
				if(touchPosition.x < halfScreen){									
					ball.transform.Rotate (Vector3.down * 80 * Time.deltaTime);	
					if (280 > ball.transform.eulerAngles.y && !(ball.transform.eulerAngles.y >= 0 && ball.transform.eulerAngles.y <= 80)) {
						temp = ball.transform.eulerAngles;
						temp.y = 280;
						ball.transform.eulerAngles = temp;
					}

				} else if (touchPosition.x > halfScreen) {					
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

	float fixedAngle(float angle, float min, float max){
		Debug.Log (angle);

		if (angle <= -360f) {
			angle += 360;
		}
		if (angle > 360f) {
			angle -= 360;
		}

		return Mathf.Clamp (angle, min, max);

	}



}

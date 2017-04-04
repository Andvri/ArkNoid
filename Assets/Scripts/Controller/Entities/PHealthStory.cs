using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHealthStory : MonoBehaviour {

	public int PowerHealt;
	public int Point1;
	public int PointDes;
	[Header("Explosion Particle")]
	public GameObject Explo;
	private int powerAux;

	// Use this for initialization
	void Start () {
		PointDes = Point1 * PowerHealt;
		powerAux = PowerHealt;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		PowerHealt--;
		if (PowerHealt == 0)
		{
			if (Explo != null)
			{
				var al=Instantiate(Explo);
				al.transform.position = transform.position;

			}
			if (this.gameObject.tag != "Bosses" && this.gameObject.tag != "SubBoss") {
				Destroy (gameObject);
				(GameObject.FindWithTag("GameController").GetComponent<ScoreStory>()).increase(PointDes);
				(GameObject.FindWithTag ("GameController").GetComponent<ScoreStory> ()).incDefeated ();
			} else {
				this.gameObject.SetActive (false);			
			}

			return;
		}
		(GameObject.FindWithTag("GameController").GetComponent<ScoreStory>()).increase(Point1);

	}

	public void Reset(){
		PowerHealt = powerAux;
	}
}

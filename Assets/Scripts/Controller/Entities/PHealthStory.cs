using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHealthStory : MonoBehaviour {

	public int PowerHealt;
	public int Point1;
	public int PointDes;
	public Text currentH;
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
		string textH = PowerHealt + "%";
		if (currentH != null) {
			currentH.text = textH;
			if (PowerHealt <= 0 && this.gameObject.tag == "Respawn") {
				Debug.Log ("GameOver");
				Time.timeScale = 0;
				this.gameObject.SetActive (false);
				GameObject.Find("Limits").GetComponent<LimitsController>().Louse.SetActive(true);
				Destroy(GameObject.Find("Limits").GetComponent<LimitsController>().Help);		 

			}
		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag != "Respawn") {
			PowerHealt--;
			(GameObject.FindWithTag ("GameController").GetComponent<ScoreStory> ()).increase (Point1);
		}

		if (PowerHealt <= 0 && this.gameObject.tag != "Respawn")
		{
			if (Explo != null)
			{
				var al=Instantiate(Explo);
				al.transform.position = transform.position;

			}

			if (this.gameObject.tag != "Bosses" && this.gameObject.tag != "SubBoss") {
				Destroy (gameObject);
				(GameObject.FindWithTag ("GameController").GetComponent<ScoreStory> ()).increase (PointDes);
				(GameObject.FindWithTag ("GameController").GetComponent<ScoreStory> ()).incDefeated ();
			}else{
				this.gameObject.SetActive (false);			
			}

			return;
		}



	}

	public void DecreaseHealth(){
		PowerHealt -= 2;
	}

	public void Reset(){
		PowerHealt = powerAux;
	}
}

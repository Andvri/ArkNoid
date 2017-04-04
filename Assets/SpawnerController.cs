using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public Spawner[] spawners;
	public GameObject[] unlockables;
	public GameObject[] bosses;
	public int limit;
	public static int currentPoint;
	public static int currentBox;
	public static int currentBoss;

	public static bool changeCourse;
	public static bool bossFight;
	public static bool continueLimit;

	private PHealthStory[] restoreData;

	private 
	// Use this for initialization
	void Start () {
		limit = 9;	
		bossFight = false;
		currentBox = 0;
		currentPoint = 0;
		currentBoss = 0;
		changeCourse = false;
		continueLimit = true;
		spawners [currentPoint].gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		string actual = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ScoreStory> ().NDes.text.ToString ();
		int currentDestroyed = int.Parse (actual);

		//Debug.Log ((currentDestroyed == limit)+" "+continueLimit);


		if (currentDestroyed == limit && continueLimit){
			//Debug.Break ();
			continueLimit = false;
			Debug.Log ("Current Spawn:"+currentPoint);
			spawners[currentPoint].gameObject.SetActive (false);
			currentPoint = (currentPoint + 1 < spawners.Length) ? currentPoint+1 : 0; 

			GameObject[] remains = GameObject.FindGameObjectsWithTag ("Destructible Entity");
			foreach(GameObject remaining in remains){
				Destroy (remaining);
			}

			if (!bossFight) {
				unlockables [currentBox].gameObject.SetActive (true);
			}


		}

		if (changeCourse) {
			//Debug.Break ();
			unlockables[currentBox].gameObject.SetActive (false);
			currentBox = (currentBox+1 < unlockables.Length) ? currentBox+1 : 0;
			changeCourse = false;

			if (!bossFight) {
				Debug.Log ("Not a Boss fight");
				Debug.Log ("Change Course Spawn:"+currentPoint);
				spawners [currentPoint].gameObject.SetActive (true);				
			} else {
				Debug.Log ("Boss Fight!");
				Debug.Log ("Change Course Spawn:"+currentPoint);
				Debug.Log("Spawner Active? "+spawners [currentPoint].gameObject.activeSelf);	
				SpawnBoss ();
				SpawnerController.bossFight = true;
							
			}
			continueLimit = true;
			limit += 9;
		}

		if (bossFight) {
			
			if (bosses [currentBoss].GetComponent<PHealthStory> () != null) {

				if (bosses [currentBoss].GetComponent<PHealthStory> ().PowerHealt == 0) {
					bossFight = false;
					continueLimit = true;
								
					spawners [currentPoint].gameObject.SetActive (true);
					currentBoss = (currentBoss + 1 < bosses.Length) ? currentBoss + 1 : 0;		
				}

			} else {

				GameObject[] ZuH = GameObject.FindGameObjectsWithTag ("SubBoss");
				//Debug.Log (ZuH.Length);

				if (ZuH.Length == 0) {
					removeBoss ();	
					currentBoss = 0;
					currentBox = 0;
					currentPoint = 0;
					changeCourse = false;
					spawners [currentPoint].gameObject.SetActive (true);
					continueLimit = true;
					bossFight = false;
					Reset ();
				}




			}

		}
	}

	void SpawnBoss(){
		bosses [currentBoss].SetActive (true);
		Transform [] toAct = bosses[currentBoss].GetComponentsInChildren<Transform>(true);
		Debug.Log (toAct.Length);
		foreach (Transform finalStep in toAct) 
		{
			if (finalStep.childCount > 0) {
				for (int i = 0; i < finalStep.childCount; i++) 
				{
					finalStep.GetChild (i).gameObject.SetActive (true);
				}
			}
		}				
	}

	void removeBoss(){
		bosses [currentBoss].SetActive (false);
		Transform [] toAct = bosses[currentBoss].GetComponentsInChildren<Transform>(true);			
		foreach (Transform finalStep in toAct) 
		{
			if (finalStep.childCount > 0) {
				for (int i = 0; i < finalStep.childCount; i++) 
				{
					finalStep.GetChild (i).gameObject.SetActive (false);
				}
			}
		}	
	}

	void Reset(){		
		GameObject aux = GameObject.Find ("Bosses");
		PHealthStory[] backup = aux.GetComponentsInChildren<PHealthStory> (true);

		foreach(PHealthStory enable in backup){
			enable.Reset ();
		}
	}


}

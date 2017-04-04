using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextUnlock : MonoBehaviour {
	
	public int unlockLvl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){
		
		switch (unlockLvl) 
		{
			case 0:
			{
				
				GameObject[] toActivate = GameObject.FindGameObjectsWithTag ("Turret");
				Debug.Log (toActivate.Length);
				foreach(GameObject aux in toActivate)
				{
					aux.transform.Find ("Torre").gameObject.SetActive (true);
					aux.transform.Find ("h2").gameObject.SetActive (false);
					GameObject finalAct = aux.transform.Find ("Cruz").gameObject;
					finalAct.SetActive (true);

					if (finalAct.GetComponent<RandomDirection> ()) {
						finalAct.GetComponent<RandomDirection> ().move = true;
					}
					if (finalAct.GetComponent<SpawnMove> ()) {
						finalAct.GetComponent<SpawnMove> ().XAxis = true;
					}


				}

				SpawnerController.changeCourse = true;
				break;
			}		

			case 1:
			{				
				GameObject[] toActivate = GameObject.FindGameObjectsWithTag ("Turret");
				Debug.Log (toActivate.Length);
				foreach(GameObject aux in toActivate)
				{
					Transform [] toAct = aux.gameObject.GetComponentsInChildren<Transform>(true);

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

				SpawnerController.changeCourse = true;
				SpawnerController.bossFight = true;
				break;	
			}

		}

	}	

}

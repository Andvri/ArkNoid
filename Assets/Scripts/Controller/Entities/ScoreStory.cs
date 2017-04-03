using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreStory : MonoBehaviour {
	
	public Text Num;
	public Text NDes;
	// Use this for initialization
	void Start()
	{
		Num.text = "0";
		NDes.text = "0";
	}


	// Update is called once per frame
	void Update()
	{

	}
	public void increase(int n)
	{
		string num = Num.text;
		Num.text = (int.Parse(num) + n).ToString();	
	}

	public void incDefeated(){
		NDes.text = (int.Parse (NDes.text) + 1).ToString ();
	}
}

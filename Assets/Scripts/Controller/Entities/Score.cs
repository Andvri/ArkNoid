using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public Text Num;
    // Use this for initialization
    void Start()
    {
        Num.text = "0";
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
}

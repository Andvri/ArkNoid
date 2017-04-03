using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
    public float s;
    public float m;
    public float h;
    public Text text;
    public string Tiempo;
    private void Awake()
    {
        Tiempo = "";
        text = GetComponent<Text>();
    }
    // Use this for initialization
    void Start () {
        s = m = h = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        s += Time.deltaTime;
        if (s >= 60)
        {
            s = 0;
            m++;
            if (m >= 60)
            {
                m = 0;
                h++;
            }

        }
        UpdateTimer();

	}
    private void UpdateTimer()
    {
        Tiempo = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
        text.text = Tiempo;
    }
    public string TiempoS()
    {
        return Tiempo;
    }
}

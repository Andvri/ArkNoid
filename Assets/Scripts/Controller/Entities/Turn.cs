using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {
    public int orientation;
    public int intensity;
    // Use this for initialization
    void Start()
    {
        intensity = 2;
        orientation = -1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(intensity * orientation * Vector3.back);
    }
    
}

using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public Vector3 ResetPosition;
    public GameObject angle;
    public touch sta;
    private Transform parent;
    public TableController controllerparent;
    // Use this for initialization
    private void Awake()
    {
        
        parent = transform.parent;
       
    }
    void Start () {
        ResetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Reset")]
    public void Reset()
    {
        controllerparent.Reset();
        transform.SetParent(parent);
        transform.position = ResetPosition;
        Rigidbody ball = GetComponent<Rigidbody>();
        ball.velocity = Vector3.zero;
        angle.SetActive(true);
        sta.play = false;
    }
}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class TableController : MonoBehaviour {
    private Rigidbody rig;
    public GameObject particles;
    // Use this for initialization
    public void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float moveH = CrossPlatformInputManager.GetAxis("Horizontal");
        float newX = (moveH * Time.deltaTime * 50)+ rig.transform.position.x;
        rig.transform.position = new Vector3(Mathf.Clamp(newX, -10, 10), transform.position.y, transform.position.z);
        particles.transform.Rotate(new Vector3(0, Mathf.Clamp(moveH*-40, -40, 40), 0)) ;
    }

    // Si la clase MonoBehaviour está habilitada, se llama a esta función en cada fotograma de velocidad de fotograma fija
    private void FixedUpdate()
    {
        
        
    }

}

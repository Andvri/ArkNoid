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

      //  particles.transform.Rotate(new Vector3(0,-1, 0), moveH*-40*Time.deltaTime);

       particles.transform.rotation.SetAxisAngle(new Vector3(0,-1,0), moveH * -0 * Time.deltaTime);
   //     currentRotation.y = Mathf.Clamp(currentRotation.y, -40, 40);

   //     particles.transform.rotation = Quaternion.Euler(currentRotation);
       
       
    }

    // Si la clase MonoBehaviour está habilitada, se llama a esta función en cada fotograma de velocidad de fotograma fija
    private void FixedUpdate()
    {
        
        
    }

}

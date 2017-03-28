using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class TableController : MonoBehaviour {
    
    // Use this for initialization
    public void Awake()
    {
       
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     
       
       
    }

    // Si la clase MonoBehaviour está habilitada, se llama a esta función en cada fotograma de velocidad de fotograma fija
    private void FixedUpdate()
    {
        
        
    }
    [ContextMenu("Reset")]
    public void Reset()
    {
        transform.position = Vector3.zero;
    }

}

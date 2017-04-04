using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class TableController : MonoBehaviour {
    public GameObject player0;
    public GameObject prePlayer;
    // Use this for initialization
    public void Awake()
    {
       
    }
    void Start () {
        instatiate();
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
        transform.localScale = Vector3.one;
        GameObject.Find("Player").GetComponent<Transform>().localScale = Vector3.one;
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play != false)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
            foreach (var item in balls)
            {
                Destroy(item);
            }
            instatiate();
        }
        
        GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play = false;
    }

    public void Reset2()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one;
       
      if (GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play != false)
        {
           instatiate();
        }

        GameObject.FindGameObjectWithTag("GameController").GetComponent<touch>().play = false;
    }

    public Object instatiate()
    {
        return Instantiate(prePlayer,player0.transform);
    } 

}

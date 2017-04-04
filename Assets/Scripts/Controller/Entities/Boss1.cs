using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {
    public GameObject ring;
    private int numberofChild;
    public int speed;
    public Vector3 despl;
    public float timetoshoot;
    private float time;
    [Header("Shoot")]
    public GameObject instatiate;
    public GameObject patnerinst;
	// Use this for initialization
	void Start () {
        speed = 1;
        numberofChild = ring.transform.childCount;

        despl = Vector3.back * (1f / ring.transform.childCount);

    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time>= (timetoshoot* ring.transform.childCount))
        {
            time = 0f;
            GameObject c1 = (GameObject) Instantiate(instatiate);
            c1.transform.localPosition = transform.position;
            c1.transform.Rotate(Vector3.left * -90);
            c1.GetComponent<Beam>().Boom();
            
        }
        if (ring.transform.childCount < numberofChild)
        {
            numberofChild = ring.transform.childCount;
            (ring.GetComponent<Turn>()).orientation *= -1;
            (ring.GetComponent<Turn>()).intensity += 1;
            speed++;
        }
		/*
        if (transform.position.x <= -4)
        {
            despl = (new Vector3(Random.Range(0f, 0.1f), 0, Random.Range(-0.1f, 0.1f)));

        }
        if (transform.position.x >= 4)
        {
            despl = (new Vector3(-Random.Range(0f, 0.1f), 0, Random.Range(-0.1f, 0.1f)));

        }
        if (transform.position.z <= 22)
        {
            despl = (new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(0f, 0.1f)));

        }
        if (transform.position.z >= 28)
        {
            despl = (new Vector3(Random.Range(-0.1f, 0.1f), 0, -Random.Range(0f, 0.1f)));

        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + (despl.x*speed),-4,4),0,Mathf.Clamp(transform.position.z + (despl.z*speed),22,28));
        */
	}

    // Si la clase MonoBehaviour está habilitada, se llama a esta función en cada fotograma de velocidad de fotograma fija
    private void FixedUpdate()
    {
        

    }


    private void Move()
    {
        
    }

}

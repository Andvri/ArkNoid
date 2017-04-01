using UnityEngine;
using System.Collections;

public class BlockPowerUp : MonoBehaviour {
    public GameObject powerUp;
    // Se llama a OnCollisionEnter cuando este colisionador o cuerpo rígido comienza a tocar a otro cuerpo rígido o colisionador
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            powerUp.transform.SetParent(null);
            powerUp.GetComponent<ConstantForce>().force = Vector3.back * 5;
               Destroy(gameObject);
        }

    }

    // Use this for initialization

}

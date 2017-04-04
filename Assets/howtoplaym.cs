using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class howtoplaym : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Invoke("c", 5);

    }

    private void c()
    {
        SceneManager.LoadScene("MainScene");
    }

	
}

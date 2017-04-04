using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScripTest : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        Invoke("ChangeScene", 1);
    }
    private void ChangeScene()
    {
        string scene = GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SceneToLoad;
        SceneManager.LoadScene(scene);
    }


}


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
    public string SceneName;
    public float time;

    public void Awake()
    {
       
        SceneName = "Level1";
        time = 0.5f;
    }
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
    }
   
    public void LoadScene() {
        Invoke("_ChangeScene", time);
    } 

    public void _ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void L1() {
        SceneName = "1";
        LoadScene();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Sali de la app");
    }
    public void backToMainScene() {
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }
    public void changenextsceneArcade()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene((1+int.Parse(name)).ToString(), LoadSceneMode.Single);
    }
}

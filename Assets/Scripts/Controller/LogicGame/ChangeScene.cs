using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
    public string SceneName;
    
    public float time;

    public void Awake()
    {
       
        SceneName = "1";
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
        SceneManager.LoadSceneAsync(SceneName);
    }
    public void L1() {
        SceneName = "LoadingScene";
        LoadScene();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Sali de la app");
    }
    public void backToMainScene() {
        SceneManager.LoadSceneAsync("MainScene",LoadSceneMode.Single);
    }
    public void changenextsceneArcade()
    {
        string name = SceneManager.GetActiveScene().name;
        int numescene = int.Parse(name);
        
        if (numescene >= 10)
        {
            numescene = 0;
        }
        else if ((GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SelectionLevel && (GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().times[numescene] == "00:00:00")))
            {
                numescene = 0;
            }
        
        SceneManager.LoadScene((1+numescene).ToString(), LoadSceneMode.Single);
    }
    public void selectscene(int opc)
    {
        if (opc != 0)
        {
            GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SelectionLevel = true;
            GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SceneToLoad = opc.ToString();
            L1();
            
        }
        
    }
    public void starArcade()
    {

        GameObject.FindGameObjectWithTag("Persisteng").GetComponent<SaveLoad>().SceneToLoad = "1";
        L1();
    }
}

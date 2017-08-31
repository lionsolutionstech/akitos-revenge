using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public Button resume, restart, quit;
    public UIManager manager;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        resume.onClick.AddListener(Resume);
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
	}
    void Resume()
    {
        manager.isPaused = false;
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Quit()
    {
        Application.Quit();
    }
}

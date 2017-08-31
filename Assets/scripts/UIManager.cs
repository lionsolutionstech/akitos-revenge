using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject HUD;

    public bool isPaused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pauseMenu.SetActive(isPaused);
        HUD.SetActive(!isPaused);
    }

}

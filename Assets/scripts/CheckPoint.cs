using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Player")
        {
            levelManager.curCheckPoint = gameObject;
        }
    }
}

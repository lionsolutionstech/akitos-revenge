using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    public PlayerController player;
    public float bounceModifier;
    public bool instantKill = false;


	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.name == "Player")
        {
            if (instantKill)
            {
                levelManager.RespawnPlayer();
                player.health = player.maxHealth;
                return;
            }
            player.bounceBack(bounceModifier);
            player.health--;
            if(player.health <= 0)
            {
               levelManager.RespawnPlayer();
               player.health = player.maxHealth;
            }
        }
    }
}

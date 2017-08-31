using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public EnemyPatrol enemy;
    public PlayerController player;
    public float agroRange;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        enemy = GetComponent<EnemyPatrol>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(player.transform.position, enemy.transform.position) < agroRange) {
            FollowPlayer();
        }
	}

    private void FollowPlayer()
    {
        if (player.transform.position.x > enemy.transform.position.x)
        {// player is to the right
            enemy.Move(EnemyPatrol.Directions.RIGHT);
        }
        else if (player.transform.position.x < enemy.transform.position.x)
        {// player is to the left
            enemy.Move(EnemyPatrol.Directions.LEFT);
        }
        else
        {
            enemy.Move(EnemyPatrol.Directions.NONE);
        }
    }
}

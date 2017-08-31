using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferAI : MonoBehaviour {
    public PlayerController player;
    public float agroRange;
    public float speed;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) < agroRange)
        {
            GetComponent<Rigidbody2D>().velocity = (player.transform.position - gameObject.transform.position)* speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

}

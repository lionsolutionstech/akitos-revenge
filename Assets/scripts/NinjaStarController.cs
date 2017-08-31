using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

    public float speed, rotationSpeed;
    private PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject imapctEffect;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        // adjust shooting direction
        speed *= player.transform.localScale.x;
        rotationSpeed *= player.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = 
            new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
	}
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Player") return;
        if (obj.tag == "Check Point") return;
        if (obj.tag == "Enemy")
        {
            Instantiate(enemyDeathEffect, obj.transform.position, obj.transform.rotation);
            Destroy(obj.gameObject);
        }
        Instantiate(imapctEffect, obj.transform.position, obj.transform.rotation);
        Destroy(gameObject);
    }
}

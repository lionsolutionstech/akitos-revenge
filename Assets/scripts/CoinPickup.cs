using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int pointValue;
    public GameObject coinEffect;
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.GetComponent<PlayerController>() == null) return;
        ScoreManager.AddPoints(pointValue);
        Instantiate(coinEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}

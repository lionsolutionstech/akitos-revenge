using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public Transform transportLocation;
    public GameObject effect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.name == "Player")
        {
            obj.gameObject.transform.position = transportLocation.position;
            Instantiate(effect, transportLocation.position, transportLocation.rotation);
        }
    }
}

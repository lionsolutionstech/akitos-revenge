using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMeter : MonoBehaviour {
    public RectTransform meter;
    public PlayerController player;
    private static float maxWidth;
	// Use this for initialization
	void Start () {
        meter = gameObject.GetComponent<RectTransform>();
        maxWidth = meter.rect.width;
	}
	
	// Update is called once per frame
	void OnGUI () {
        meter.sizeDelta = new Vector2(((float)player.health / (float)player.maxHealth) * maxWidth, meter.rect.height);

	}
}

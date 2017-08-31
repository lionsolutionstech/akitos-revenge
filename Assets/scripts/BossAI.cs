using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    public Animator anim;
    public bool attacking = false;
    private float time;
    public float atkCycle;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("attacking", attacking);
        time += Time.deltaTime;
        if(time >= atkCycle)
        {
            attacking = !attacking;
            time = 0;
        }
	}
}

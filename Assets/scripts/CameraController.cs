using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private PlayerController player;
    public bool isFollowing;
    public float xOffset, yOffset;
    public Transform boss;
    public bool bossRoom;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            transform.position = new Vector3 (
                player.transform.position.x + xOffset,
                player.transform.position.y + yOffset,
                transform.position.z
                );
        }
        if (bossRoom)
        {
            transform.position = boss.position;
            isFollowing = false;
        }
	}
}

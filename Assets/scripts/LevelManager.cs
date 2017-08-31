using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject curCheckPoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    public int pointPenality;

    private PlayerController player;
    private CameraController camera;
    private float gravityStore;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
 
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
        ScoreManager.AddPoints(-pointPenality);
    }
    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        TogglePlayer();
        yield return new WaitForSeconds(respawnDelay);
        TogglePlayer();
        player.transform.position = curCheckPoint.transform.position;
        Instantiate(respawnParticle, curCheckPoint.transform.position, curCheckPoint.transform.rotation);
    }
    private void TogglePlayer()
    {
        player.enabled = !player.enabled;
        camera.isFollowing = !camera.isFollowing;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Renderer>().enabled = !player.GetComponent<Renderer>().enabled;
        if (!player.enabled)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        }
    }
}

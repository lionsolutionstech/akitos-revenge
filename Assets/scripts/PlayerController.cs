using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed, jumpHeight;
    public float anchorRadius;
    public Transform anchor;
    public LayerMask ground;
    public Animator anim;
    public int health;
    public int maxHealth;

    public Transform firePoint;
    public GameObject ninjaStar;
    public float shotDelay;
    private float shotDelayCounter;

    private bool jumped;
    private bool inputsActive;
    public bool grounded;

    public GameObject bubbles;

    private enum Directions { NONE, RIGHT, LEFT };

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        health = maxHealth;
	}
	
    void FixedUpdate(){

        grounded = Physics2D.OverlapCircle(anchor.position, anchorRadius, ground);
        
    }

	// Update is called once per frame
	void Update () {
        if (inputsActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Directions.LEFT);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Directions.RIGHT);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Shoot();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpHeight);
            }
            else if (Input.GetKey(KeyCode.Return))// if held down
            {
                // decrement counter each game second
                shotDelayCounter -= Time.deltaTime;
                if (shotDelayCounter <= 0)
                {
                    Shoot();// this also resets the counters
                }
            }
            else { Move(Directions.NONE); }
        }
        else if (grounded)
        {
            inputsActive = true;
        }
        UpdateAnimations();
    }
    private void Shoot()
    {
        shotDelayCounter = shotDelay; // reset counter
        Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
    }
    // Make character jump while maintaining horizontal motion
    private void Jump()
    {
        if (grounded || jumped)
        {
            if(!(grounded & jumped)) // mod2 jump counter
            {
                jumped = !jumped; // increment counter
            }
          GetComponent<Rigidbody2D>().velocity =
            new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Destroy(Instantiate(bubbles, anchor.position, anchor.rotation), 1f);
        }
    }
    // Move character either left or right
    private void Move(Directions direction)
    {
        float moveVelocty = 0f;
        switch (direction)
        {
            case Directions.LEFT:
                moveVelocty = -moveSpeed;
                break;
            case Directions.RIGHT:
                moveVelocty = moveSpeed;
                break;
            default:
                break;

        }
        GetComponent<Rigidbody2D>().velocity =
                    new Vector2(moveVelocty, GetComponent<Rigidbody2D>().velocity.y);
    }
    public void bounceBack(float bounceModifier = 1f)
    {
        float x = 2 * bounceModifier * -transform.localScale.x; // move away from current orientation
        float y = bounceModifier;
        if (grounded)
        {
            GetComponent<Rigidbody2D>().velocity =
                    new Vector2(x, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity =
                        new Vector2(x, y);
        }
        inputsActive = false; // disable inputs until character is grounded
    }
    private void UpdateAnimations()
    {
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Jump", !grounded & jumped);
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {// Moving right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {// Moving left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}

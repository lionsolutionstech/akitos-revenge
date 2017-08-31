using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed, jumpHeight;
    public bool jumped, grounded, atEdge;
    public float anchorRadius;
    public Transform anchor;
    public LayerMask ground;
    public Transform edgeCheck;
    public bool invertFlip;
    private static int flipBias;

    public enum Directions { NONE, RIGHT, LEFT };
    public Directions orientation = Directions.LEFT;

	// Use this for initialization
	void Start () {
        if (invertFlip)
        {
            flipBias = -1;
        }
        else
        {
            flipBias = 1;
        }
	}

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(anchor.position, anchorRadius, ground);
        atEdge = Physics2D.OverlapCircle(edgeCheck.position, anchorRadius, ground);

    }

    // Update is called once per frame
    void Update () {
        
        UpdateAnimation();
	}
    
    public void Jump()
    {
        if (grounded || jumped)
        {
            if (!(grounded & jumped)) // mod2 jump counter
            {
                jumped = !jumped; // increment counter
            }
            GetComponent<Rigidbody2D>().velocity =
              new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
    }
    // Move character either left or right
    public void Move(Directions direction)
    {
        float moveVelocty = 0f;
        if (!atEdge)// overide direction for protection
        {
            if (orientation == Directions.LEFT ^ orientation == Directions.RIGHT)
            {
                direction = Directions.NONE;
            }
        }
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
    private void UpdateAnimation()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {// Moving right
            orientation = Directions.RIGHT;
            transform.localScale = new Vector3(-1f * flipBias, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {// Moving left
            orientation = Directions.LEFT;
            transform.localScale = new Vector3(1f * flipBias, 1f, 1f);
        }
    }
}

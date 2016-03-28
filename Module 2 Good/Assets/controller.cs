using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

    public float maxS = 10f;
    bool right = true;
    bool ground = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public float jumpForce = 700f;
    public LayerMask whatGround;
    public bool canDoubleJump; 


	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                }
            
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatGround);


        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxS, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !right)
            Flip();
        else
        {
            if (move < 0 && right)
                Flip();
        }
	
	}

    void Flip()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
}

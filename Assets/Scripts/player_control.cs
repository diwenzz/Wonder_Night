using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class player_control : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;


    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    public bool isGround, isJump;
    public string msg;
    public int currentHp = 100;

    bool jumpPressed;
    int jumpCount;
    UnityEvent my_event;
    Vector2 movement;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //rotates the player 
        if (movement.x !=0)
        {
            transform.localScale = new Vector3(movement.x, 1, 1);
        }


        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
    }


    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        GroundMovement();
        Jump();
        SwitchAnim();
        Attack(msg);
    }

    private void GroundMovement()
    {
        rb.MovePosition(rb.position + movement*speed*Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (isGround)
        {
            jumpCount = 2; //default double jump
            isJump = false;
        }

        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            //double jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

    private void SwitchAnim()
    {
        anim.SetFloat("running", movement.magnitude);
        if (isGround)
        {
            //if on the ground, falling should end
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y>0)
        {
            //jumping
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y<0)
        {
            //falling
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }

    public void Attack(string msg)
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attacking", true);
        }
        if (msg.Equals("End"))
        {   
            anim.SetBool("attacking", false);
            // Do other things based on an attack ending.
        }

    }

}

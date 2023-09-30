using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 60f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    bool isGrounded = false;

    private bool isFacingRight = true;
    private float verticalSpeed;
    private float groundRadius = 0.1f;
    private Rigidbody2D rb2d;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //physics 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        verticalSpeed = rb2d.velocity.y;

        anim.SetBool("onGround", isGrounded);

        //move
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            anim.SetFloat("Speed", rb2d.velocity.x);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            anim.SetFloat("Speed", rb2d.velocity.x);
        }

        //jump
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("onGround", false);
            anim.SetTrigger("initJump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
        else if (!isGrounded)
        {
            anim.SetTrigger("initJump");
        }

        //flip
        if (rb2d.velocity.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (rb2d.velocity.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }

}

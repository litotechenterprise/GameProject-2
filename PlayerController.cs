using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    Rigidbody2D rb;

    Vector2 force;

    public bool isGrounded;

    Animator anim;

    bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 1.5f, transform.position.y - 1.5f), 
            new Vector2 (transform.position.x + 1.5f, transform.position.y - 1.51f), groundLayer);

            if (isGrounded)
            {
                force.y = 300;
            }
        }

        if (force.x < 0)
        {
            anim.SetBool("isWalking", true);

            if (facingRight) 
            {
                Flip();
            }
        }
        else if (force.x > 0)
        {
            anim.SetBool("isWalking", true);

            if (facingRight == false) 
            {
                Flip();
            }
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }

        if ( rb.velocity.y == 0)
        {
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling",false);
        }

        if (rb.velocity.y > 1)
        {
            anim.SetBool("isJumping", true);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling",true);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -8, 8), rb.velocity.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}

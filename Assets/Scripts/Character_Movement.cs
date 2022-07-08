using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    private bool jumping = false;
    //for mass of 80
    public float spd = 600f;
    public float jumpSpd = 1800f;
    public float gravity = 240f;
    public float fallingGravity = 600f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Movement()
    {
        if (!jumping && rb.velocity.y == 0)  { 
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                //rb.AddForce(Vector2.up * jumpSpd, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpd);
            }
        }

        if (rb.velocity.y >= -0.1)
        {
            rb.gravityScale = gravity;
        }
        else
        {
            rb.gravityScale = fallingGravity;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 moveDir = new Vector3(-spd, 0).normalized;
            transform.position += moveDir * spd * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 moveDir = new Vector3(spd, 0).normalized;
            transform.position += moveDir * spd * Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform") jumping = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform") jumping = true;
    }

    void Update()
    {
        Movement();
    }
}

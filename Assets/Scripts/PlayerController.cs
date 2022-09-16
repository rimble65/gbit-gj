using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public float moveSpeed;
    public Animator ani;




    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        GroundMove();
    }

    void GroundMove()
    {
        float verticalMove = Input.GetAxisRaw("Vertical");

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);

        if (horizontalMove < 0)
        {
            ani.Play("side");
            transform.localScale = new Vector3(Mathf.Max(transform.localScale.x, -transform.localScale.x) , transform.localScale.y, transform.localScale.z);
        }
        else if(horizontalMove > 0)
        {
            ani.Play("side");
            transform.localScale = new Vector3(Mathf.Min(transform.localScale.x, -transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (verticalMove < 0)
        {
            ani.Play("down");
        }
        else if (verticalMove > 0)
        {
            ani.Play("up");
        }
        else
        {
            ani.Play("Idle");
        }
    }
}
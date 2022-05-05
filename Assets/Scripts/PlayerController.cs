using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public float moveSpeed;




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
            transform.localScale = new Vector3(Mathf.Max(transform.localScale.x, -transform.localScale.x) , transform.localScale.y, transform.localScale.z);
        }
        else if(horizontalMove > 0)
        {
            transform.localScale = new Vector3(Mathf.Min(transform.localScale.x, -transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
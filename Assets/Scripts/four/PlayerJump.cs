using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;//检测是否踩在地板上 否则不能起跳
    public LayerMask ground;//设置那些东西是地板
    private bool isGround;


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        Debug.Log(isGround);
        GroundMove();
        
    }
    private void Update()
    {
        Jump();
        
    }
    void GroundMove()
    {

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(Mathf.Max(transform.localScale.x, -transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(Mathf.Min(transform.localScale.x, -transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.K))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

}
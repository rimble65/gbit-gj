using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxPlayer : MonoBehaviour
{
    Vector2 moveDir;
    Vector3 initPos;
    public LayerMask detectLayer;

    private void Awake()
    {
        initPos = transform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            moveDir = Vector2.right;

        if (Input.GetKeyDown(KeyCode.A))
            moveDir = Vector2.left;

        if (Input.GetKeyDown(KeyCode.W))
            moveDir = Vector2.up;

        if (Input.GetKeyDown(KeyCode.S))
            moveDir = Vector2.down;

        if (moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }

        moveDir = Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 144, detectLayer);
        if (!hit)
            return true;
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
            {
                return hit.collider.GetComponent<Box>().CanMoveToDir(dir);
            }

        }

        return false;
    }

    void Move(Vector2 dir)
    {
        if (dir == Vector2.right)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 120, transform.localPosition.y, transform.localPosition.z);
        }
        else if (dir == Vector2.left)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - 120, transform.localPosition.y, transform.localPosition.z);
        }
        else if(dir == Vector2.up)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+120, transform.localPosition.z);
        }
        else if (dir == Vector2.down)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 120, transform.localPosition.z);
        }
    }
}

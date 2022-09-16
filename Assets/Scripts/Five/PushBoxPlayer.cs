using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushBoxPlayer : MonoBehaviour
{
    public Text text;
    Vector2 moveDir;
    Vector3 initPos;
    public LayerMask detectLayer;
    private AudioController ac;
    public int step;
    public Box box;
    public Sprite side;
    public Sprite up;
    public Sprite down;
    private float scale;
    private bool tipFlag = true;
    public GameObject tipPanel;
    private void Awake()
    {
        scale = transform.localScale.x;
        step = 120;
        ac = GameObject.Find("AudioSource").GetComponent<AudioController>();
        ac.PlayFiveG();
        initPos = transform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tipFlag = !tipFlag;
            tipPanel.SetActive(tipFlag);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDir = Vector2.right;
            transform.GetComponent<Image>().sprite = side;
            transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
        }
            

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDir = Vector2.left;
            transform.GetComponent<Image>().sprite = side;
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
        }
            

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDir = Vector2.up;
            transform.GetComponent<Image>().sprite = up;
        }
            

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDir = Vector2.down;
            transform.GetComponent<Image>().sprite = down;
        }
            

        if (moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
                step--;
                if (step < 0)
                {
                    ReStart();
                }
                text.text = step.ToString();
            }
        }

        moveDir = Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 120, detectLayer);
        
        if (!hit)
            return true;
        else
        {
            Debug.Log(hit.collider);
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


    public void ReStart()
    {
        transform.localPosition = initPos;
        box.ReStart();
        step = 120;
        transform.GetComponent<Image>().sprite = down;
    }
}

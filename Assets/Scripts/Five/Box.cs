using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public LayerMask layer;
    public int nextScene;
    public GameObject fiveHun;
    private Vector3 initPos;
    private AudioSource audioSource;
    public AudioClip audioClip;
    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
        initPos = transform.localPosition;
    }
    public bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position ,dir ,120,layer);
        if (!hit)
        {
            MoveToDir(dir);
            return true;
        }
        else
        {
            if (hit.collider.name == "End")
            {
                MoveToDir(dir);
                audioSource.PlayOneShot(audioClip);
                fiveHun.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3f).OnComplete(()=> {
                    SceneManager.LoadScene(nextScene);
                });
                
            }
        }

        return false;
    }
    private void MoveToDir(Vector2 dir)
    {
        if (dir == Vector2.right)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 120, transform.localPosition.y, transform.localPosition.z);
        }
        else if (dir == Vector2.left)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - 120, transform.localPosition.y, transform.localPosition.z);
        }
        else if (dir == Vector2.up)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 120, transform.localPosition.z);
        }
        else if (dir == Vector2.down)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 120, transform.localPosition.z);
        }
    }
    public void ReStart()
    {
        transform.localPosition = initPos;
    }
}
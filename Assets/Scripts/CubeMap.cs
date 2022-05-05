using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMap : MonoBehaviour
{
    public GameObject player;
    private float y = 0;
    public float rotateSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TurnCubeLeft();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            TurnCubeRight();
        }
    }

    public void TurnCubeLeft()
    {
        y += 90;
        transform.DOLocalRotate(new Vector3(0,y,0), rotateSpeed);
        player.transform.DOLocalMoveX(player.transform.localPosition.x - 10,rotateSpeed);
        
    }
    public void TurnCubeRight()
    {
        y -= 90;
        transform.DOLocalRotate(new Vector3(0, y, 0), rotateSpeed);
        player.transform.DOLocalMoveX(player.transform.localPosition.x + 10, rotateSpeed);
    }
}

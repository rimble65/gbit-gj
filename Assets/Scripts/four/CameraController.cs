using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 initPos;
    public GameObject endPos;
    private bool flag;//true 移动到目的地了 false 还没有
    private void Awake()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false) Move();
    }
    private void Move()
    {
        Vector3 startPositon = transform.position;
        Vector3 endPosition = endPos.transform.position;
        float dis = Vector3.Distance(startPositon, endPosition);
        transform.position = Vector3.Lerp(startPositon, endPosition, 1 / dis * Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, endPosition) <= 1f)
        {
            transform.position = endPosition;
            flag = true;
        }
    }
    public void ReStartGames()
    {
        transform.position = initPos;
        flag = false;
    }
}

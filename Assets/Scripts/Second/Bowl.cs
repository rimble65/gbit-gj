using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public List<Transform> positionList;
    private int index;
    public float moveSpeed;
    private FishManager manager;
    private Vector3 initPos;

    private void Awake()
    {
        initPos = transform.position;
        manager = GameObject.Find("GameManager").GetComponent<FishManager>();
    }
    private void Update()
    {
        Move();

    }
    private void Move()
    {
        Vector3 startPositon = transform.position;
        Vector3 endPosition = positionList[index].transform.position;
        float dis = Vector3.Distance(startPositon, endPosition);
        transform.position = Vector3.Lerp(startPositon, endPosition, 1 / dis * Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, endPosition) <= 1f)
        {
            transform.position = endPosition;
            index++;
            if (index >= positionList.Count) index = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.GameOver();
    }
    public void InitPos()
    {
        index = 0;
        transform.position = initPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public List<Transform> localPositionList;
    private int index;
    public float moveSpeed;
    public GroupControllerSec gc;
    public WordMove player;

    private void Update()
    {
        Patrol();
    }
    private void Patrol()
    {
        Vector3 startPositon = transform.localPosition;
        Vector3 endPosition = localPositionList[index].transform.localPosition;
        float dis = Vector3.Distance(startPositon, endPosition);
        transform.localPosition = Vector3.Lerp(startPositon, endPosition, 1 / dis * Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.localPosition, endPosition) <= 1f)
        {
            transform.localPosition = endPosition;
            index++;
            if (index >= localPositionList.Count) index = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gc.ReStartGame();
        player.ReStart();
    }
}

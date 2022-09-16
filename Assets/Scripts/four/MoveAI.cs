using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour
{
    public List<Transform> lists;
    private int index;
    public float moveSpeed;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 startPositon = transform.localPosition;
        Vector3 endlocalPosition = lists[index].transform.localPosition;
        float dis = Vector3.Distance(startPositon, endlocalPosition);
        transform.localPosition = Vector3.Lerp(startPositon, endlocalPosition, 1 / dis * Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.localPosition, endlocalPosition) <= 1f)
        {
            transform.localPosition = endlocalPosition;
            index++;
            if (index >= lists.Count) index = 0;
        }
    }
}

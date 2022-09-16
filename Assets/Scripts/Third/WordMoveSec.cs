using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMoveSec : MonoBehaviour
{
    private Vector3 initPos;
    public List<List<int>> leftList;
    public List<List<int>> rightList;
    public List<List<int>> topList;
    public List<List<int>> bottomList;
    private void Awake()
    {
        initPos = transform.localPosition;
        #region list
        topList = new List<List<int>>();
        topList.Add(new List<int> { -290, -162 });
        topList.Add(new List<int> { -247, -162 });
        topList.Add(new List<int> { -204, -162 });
        topList.Add(new List<int> { -247, 73 });
        topList.Add(new List<int> { -204, 73 });
        topList.Add(new List<int> { -161, 73 });
        topList.Add(new List<int> { -75, -56 });
        topList.Add(new List<int> { -32, -56 });
        topList.Add(new List<int> { -32, 30 });
        topList.Add(new List<int> { -118, -162 });

        leftList = new List<List<int>>();
        leftList.Add(new List<int> { -161, -142 });
        leftList.Add(new List<int> { -75, -142 });
        leftList.Add(new List<int> { -75, -99 });
        leftList.Add(new List<int> { 6, -13 });
        leftList.Add(new List<int> { 6, 73 });
        leftList.Add(new List<int> { 6, 116 });
        leftList.Add(new List<int> { 6, 141 });
        leftList.Add(new List<int> { -118, 116 });

        rightList = new List<List<int>>();
        rightList.Add(new List<int> { -333, -142 });
        rightList.Add(new List<int> { -161, -142 });
        rightList.Add(new List<int> { -161, -99 });
        rightList.Add(new List<int> { -75, 73 });
        rightList.Add(new List<int> { -75, 116 });
        rightList.Add(new List<int> { -78, 141 });
        rightList.Add(new List<int> { -290, 116 });
        rightList.Add(new List<int> { -118, -13 });

        bottomList = new List<List<int>>();
        bottomList.Add(new List<int> { -290, -99 });
        bottomList.Add(new List<int> { -247, -99 });
        bottomList.Add(new List<int> { -204, -99 });
        bottomList.Add(new List<int> { -247, 140 });
        bottomList.Add(new List<int> { -204, 140 });
        bottomList.Add(new List<int> { -161, 140 });
        bottomList.Add(new List<int> { -75, 30 });
        bottomList.Add(new List<int> { -32, 30 });
        bottomList.Add(new List<int> { -32, 180 });
        bottomList.Add(new List<int> { -118, -56 });

        #endregion
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (var item in topList)
            {
                if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20)
                {
                    return;

                }
            }
            if (transform.localPosition.y >= 175) return;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 38, transform.localPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

            foreach (var item in leftList)
            {
                if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
            }

            if (transform.localPosition.x <= -310) return;
            transform.localPosition = new Vector3(transform.localPosition.x - 41, transform.localPosition.y, transform.localPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

            foreach (var item in bottomList)
            {
                if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
            }

            if (transform.localPosition.y <= -155) return;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 38, transform.localPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            foreach (var item in rightList)
            {
                if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
            }

            if (transform.localPosition.x >= 40) return;
            transform.localPosition = new Vector3(transform.localPosition.x + 41, transform.localPosition.y, transform.localPosition.z);
        }
    }
    public void ReStart()
    {
        transform.localPosition = initPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMove : MonoBehaviour
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
        topList.Add(new List<int> { -290, 116 });
        topList.Add(new List<int> { -247, 116 });
        topList.Add(new List<int> { -204, 116 });
        topList.Add(new List<int> { -170, 116 });
        topList.Add(new List<int> { -118, -13 });
        topList.Add(new List<int> { -290, -56 });
        topList.Add(new List<int> { -75, 73 });
        topList.Add(new List<int> { -170, -142 });
        topList.Add(new List<int> { -204, -142 });
        topList.Add(new List<int> { -247, -142 });
        topList.Add(new List<int> { 11, -142 });

        leftList = new List<List<int>>();
        leftList.Add(new List<int> { 54, -13 });
        leftList.Add(new List<int> { 54, -56 });
        leftList.Add(new List<int> { 54, -99 });
        leftList.Add(new List<int> { -32, 116 });
        leftList.Add(new List<int> { -75, 73 });
        leftList.Add(new List<int> { -75,30 });
        leftList.Add(new List<int> { -118, -99 });
        leftList.Add(new List<int> { -247,-13 });
        leftList.Add(new List<int> { -247, 30 });
        leftList.Add(new List<int> { -118, 159 });

        rightList = new List<List<int>>();
        rightList.Add(new List<int> { -333, 160 });
        rightList.Add(new List<int> { -118, 116 });
        rightList.Add(new List<int> { -161, 73 });
        rightList.Add(new List<int> { -161, 30 });
        rightList.Add(new List<int> { -333, 30 });
        rightList.Add(new List<int> { -333, -13 });
        rightList.Add(new List<int> { -290, -99 });
        rightList.Add(new List<int> { -32, -13 });
        rightList.Add(new List<int> { -32, -56 });
        rightList.Add(new List<int> { -32, -99 });

        bottomList = new List<List<int>>();
        bottomList.Add(new List<int> { -161, 202 });
        bottomList.Add(new List<int> { -204, 202 });
        bottomList.Add(new List<int> { -247, 202 });
        bottomList.Add(new List<int> { -290, 202 });
        bottomList.Add(new List<int> { -75, 160 });
        bottomList.Add(new List<int> { -118, 116 });
        bottomList.Add(new List<int> { -290, 73 });
        bottomList.Add(new List<int> { -247, -56 });
        bottomList.Add(new List<int> { -204, -56 });
        bottomList.Add(new List<int> { -161, -56 });
        bottomList.Add(new List<int> { 11, 30 });

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
                    if (Mathf.Abs(transform.localPosition.x-item[0])<20&&Mathf.Abs(transform.localPosition.y-item[1])<20)
                    {
                        return;

                    }
                }
                if (transform.localPosition.y >= 190) return;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+43, transform.localPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {

                foreach (var item in leftList)
                {
                    if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
                }

                if (transform.localPosition.x <= -320) return;
                transform.localPosition = new Vector3(transform.localPosition.x-43, transform.localPosition.y , transform.localPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                foreach (var item in bottomList)
                {
                    if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
                }

                if (transform.localPosition.y <= -180) return;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 43, transform.localPosition.z);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {

                foreach (var item in rightList)
                {
                    if (Mathf.Abs(transform.localPosition.x - item[0]) < 20 && Mathf.Abs(transform.localPosition.y - item[1]) < 20) return;
                }

                if (transform.localPosition.x >= 50) return;
                transform.localPosition = new Vector3(transform.localPosition.x+43, transform.localPosition.y , transform.localPosition.z);
            }
    }
    public void ReStart()
    {
        transform.localPosition = initPos;
    }
}

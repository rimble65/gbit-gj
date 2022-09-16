using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FirstDotFive : MonoBehaviour
{
    private TMP_Text content;
    private List<string> contentList;
    private string currentContent;
    private int pageIndex;//段落控制
    private int cursor;//控制字符逐渐增加的游标
    private float timer;
    private GameObject tips;
    private float speed = 70f;
    private bool isLoadScene;
    public int nextScene;
    public GameObject newbg;

    public GameObject theTree;
    public GameObject xun;
    public GameObject maomao;
    public GameObject xunHappy;
    public GameObject treeLaugh;
    private List<int> flagList;

    public GameObject motou;
    private void Awake()
    {
        flagList = new List<int>();
        contentList = new List<string>();
        AddContent();
        content = transform.Find("Dialog").Find("Text").GetComponent<TMP_Text>();
        tips = transform.Find("Tips").gameObject;

        currentContent = contentList[0];
        timer = Time.time;
    }

    private void Update()
    {
        if (cursor < currentContent.Length)
        {
            tips.SetActive(false);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cursor = currentContent.Length;
                tips.SetActive(true);

            }
            else
            {
                cursor = (int)(Mathf.Min(currentContent.Length, cursor + (Time.time - timer) * speed));
                timer = Time.time;
            }
            if (cursor == currentContent.Length) tips.SetActive(true);
            content.text = currentContent.Substring(0, cursor);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (pageIndex < contentList.Count - 1)
        {
            pageIndex++;
            if (pageIndex == 3)
            {
                motou.SetActive(true);
            }
            else
            {
                motou.SetActive(false);
            }
            if (pageIndex == 5)
            {
                newbg.SetActive(true);
            }
            theTree.SetActive(flagList[pageIndex] == 0);
            maomao.SetActive(flagList[pageIndex] == 2);
            xun.SetActive(flagList[pageIndex] == 1);
            treeLaugh.SetActive(flagList[pageIndex] == 5);
            xunHappy.SetActive(flagList[pageIndex] == 10);
            currentContent = contentList[pageIndex];
            timer = Time.time;
            cursor = 0;
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    private void AddContent()
    {
        contentList.Add("“阿树？你愣着干什么？搞什么啊，我这么low的吗，讲笑话不仅不好笑还能把人整得一愣一愣的。”"); flagList.Add(1);
        contentList.Add("……"); flagList.Add(0);
        contentList.Add("“快说话啊”"); flagList.Add(2);
        contentList.Add("没有，很好笑（微笑着伸出手想摸摸她的头，但是转念一想，那时两人的关系远没到做这种亲密动作的时候，收回）"); flagList.Add(5);
        contentList.Add("“诶…你就应该多笑笑，笑起来多好看嘛~"); flagList.Add(10);
        contentList.Add("这就回来了？"); flagList.Add(0);
        contentList.Add("怎么，你还有话没说完？"); flagList.Add(2);
        contentList.Add("说完了，只是有点舍不得，好久没有看见她了，不小心就愣神了。"); flagList.Add(5);
        contentList.Add("想再见到她，就快点完成第二个任务。"); flagList.Add(2);


    }
}

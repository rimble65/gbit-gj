using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PaintCanvas : MonoBehaviour
{
    private TMP_Text content;
    private List<string> contentList;
    private List<bool> flagList;
    private string currentContent;
    private int pageIndex;//段落控制
    private GameObject theTree;
    private GameObject maoMao;
    private int cursor;//控制字符逐渐增加的游标
    private float timer;
    private GameObject tips;
    private float speed = 70f;
    public GameObject mask;
    public int nextScene;
    private void Awake()
    {
        contentList = new List<string>();
        flagList = new List<bool>();
        AddContent();
        content = transform.Find("Dialog").Find("Text").GetComponent<TMP_Text>();
        maoMao = transform.Find("Mao Mao").gameObject;
        theTree = transform.Find("The Tree").gameObject;
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
            //interval = 0.8f;
            pageIndex++;
            currentContent = contentList[pageIndex];
            timer = Time.time;
            cursor = 0;
            maoMao.SetActive(!flagList[pageIndex]);
            theTree.SetActive(flagList[pageIndex]);
            if (pageIndex == 2)
            {
                transform.gameObject.SetActive(false);
            }

        }
        else
        {
            mask.SetActive(true);
            StartCoroutine(LoadNextScence());
        }

    }
    IEnumerator LoadNextScence()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextScene);
    }
    private void AddContent()
    {
        contentList.Add("“这次是什么呢”"); flagList.Add(true);
        contentList.Add("“随意从一个点进入，不重复地走完所有的道路，这意味着你要做对所有的选择。”"); flagList.Add(false);
        contentList.Add("“有没有发现这个图案很熟悉”"); flagList.Add(false);
        contentList.Add("“没有……”"); flagList.Add(true);
        contentList.Add("“反应迟钝，这是我喵神的头像”"); flagList.Add(false);
        contentList.Add("“所以你夹带私货？”"); flagList.Add(true);
        contentList.Add("“什么什么什么，这是给你降低难度好不好，后面就没有这么容易了，哼”"); flagList.Add(false);
        contentList.Add("“那无所不能的喵神能不能告诉我后面要怎么过呢？”"); flagList.Add(true);
        contentList.Add("“简、简单，躲避漂浮的障碍就可以了！”"); flagList.Add(false);
        contentList.Add("“谢谢伟大的喵神”"); flagList.Add(true);

    }
}
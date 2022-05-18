using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CubeCanvas : MonoBehaviour
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
        else if (Input.GetKeyDown(KeyCode.G))
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
        SceneManager.LoadScene(4);
    }
    private void AddContent()
    {
        contentList.Add("这是哪，为什么这么黑？"); flagList.Add(true);
        contentList.Add("是你心里的迷宫，回溯过去的必经之路，你心里珍视的物品会为你指引方向"); flagList.Add(false);
        contentList.Add("那是什么？"); flagList.Add(true);
        contentList.Add("是五瓣魂，说明你已经通过考验了，它的力量会带领你去想去的地方，亮起的花瓣越多，力量越大，传说五片花瓣全部亮起就可以彻底改变结局，好了，我们该走了。"); flagList.Add(false);

    }
}
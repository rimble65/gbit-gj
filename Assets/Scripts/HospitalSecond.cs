using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HospitalSecond : MonoBehaviour
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
        SceneManager.LoadScene(3);
    }
    private void AddContent()
    {
        contentList.Add("你的执念就是她吧，又是一个惨兮兮的爱情故事，感觉看到了故事开头就看到了结尾，两个小年轻你侬我侬"); flagList.Add(false);
        contentList.Add("......"); flagList.Add(true);
        contentList.Add("她开始想方设法地接近我，制造一些当时很尬的话题和接触，我…一开始总是对她爱答不理，尽管她总是扑闪着一双大眼睛凑到我面前笑眯眯地问我"); flagList.Add(true);
        contentList.Add("“阿树，这个笑话是不是特好笑”“阿树，我帮你想好了你的英文名，就叫tree吧”"); flagList.Add(true);
        contentList.Add("我却仍是很生硬地告诉她“不好笑”“别烦我”“我要写作业了”（面露淡淡的嘲讽和自责，如果那时。。。）"); flagList.Add(true);
        contentList.Add("比我嘴还毒，那你是有点过分的"); flagList.Add(false);
        contentList.Add("如果能再来一次的话"); flagList.Add(true);
        contentList.Add("可以，但是需要付出一点代价"); flagList.Add(false);
        contentList.Add("什么代价都可以，反正我已经没什么可以失去的了"); flagList.Add(true);
        contentList.Add("没那么严重，我是正经使者，不是觊觎你灵魂的恶魔。只是如果想要改变，就要克服当时你心里的障碍，我带你去就知道了"); flagList.Add(false);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PV : MonoBehaviour
{
    private TMP_Text content;
    private List<string> contentList;
    private List<int> flagList;
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
        flagList = new List<int>();
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
            maoMao.SetActive(flagList[pageIndex]==2);
            theTree.SetActive(flagList[pageIndex] == 0);
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
        contentList.Add("“我看到自己的四肢逐渐透明发白，逐渐感受不到身体的重量，好似一片羽毛般漂浮在空中……”"); flagList.Add(-1);
        contentList.Add("“万籁俱寂，五感俱失，没有迎来想象中的痛苦，有的只是如陈旧的钟一般迟钝的停摆，生命就这样走到了尽头”"); flagList.Add(-1);
        contentList.Add("“生命的终结好像并不似它来时那么盛大又瞩目，就好像被无情宣读的一个概念：世界人口减一，而一个人真实存在着的喜怒哀乐却就此抹去了，仿佛从未存在。”"); flagList.Add(-1);
        contentList.Add("“可是…可是我还有想说的话没有来得及说出口”"); flagList.Add(-1);
        contentList.Add("“谁不是呢？世界上有几个人能心满意足地去死？如果可以…唉…不提也罢”"); flagList.Add(-1);
        contentList.Add("——“人类啊，什么叫‘如果可以？’如果我说你小子运气够好，我确实‘可以’赏你这个机会呢？”"); flagList.Add(2);
        contentList.Add("沉浸在无尽悔恨/悲伤/痛苦的众灵体齐刷刷看向声音发出的方向，那个说话的穿着黑袍的身影缓缓转过身，随着它的动作，袍子的一角落下，露出一个尖尖的、毛茸茸的耳朵。"); flagList.Add(-1);
        contentList.Add("“原来…生命的尽头…是一只…猫？？？”"); flagList.Add(-1);


    }
}
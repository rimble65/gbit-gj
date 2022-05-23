using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ThirdDotFive : MonoBehaviour
{
    private TMP_Text content;
    private List<string> contentList;
    private List<int> flagList;
    private string currentContent;
    private int pageIndex;//段落控制
    private GameObject theTree;
    private GameObject maoMao;
    private GameObject xun;
    private GameObject tree;
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
        tree = transform.Find("Tree").gameObject;
        theTree = transform.Find("The Tree").gameObject;
        xun = transform.Find("Xun").gameObject;
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
            tree.SetActive(flagList[pageIndex] == 3);
            maoMao.SetActive(flagList[pageIndex] == 2);
            theTree.SetActive(flagList[pageIndex] == 0);
            xun.SetActive(flagList[pageIndex] == 1);
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
        contentList.Add("然后猫猫眼睁睁地看着阿树张开双臂把浔抱在了怀里，女孩的头正好在贴在阿树微微向下靠的下巴上。"); flagList.Add(-1);
        contentList.Add("猫大人突然懂了这小子刚刚说的你不明白是什么意思，识趣地没有发出任何声音打扰两人这个本不存在的拥抱，引领了无数亡者回溯的他，此时似乎又领悟到了年少时这种懵懂的喜欢所带来的冲动和欢喜"); flagList.Add(-1);
        contentList.Add("他突然也有点不想和这小子进行下次的回溯，因为他知道，离那个注定的【时候】越来越近了。"); flagList.Add(-1);
        contentList.Add("五瓣魂已经集齐了三片。这其实并不是猫使第一次心软，但他也不得不感慨，命运太过不公，这小子一直很配合地争取回溯，尽全力地弥补自己的遗憾，最后的两瓣心魂不知道藏在怎样痛苦绝望的回忆里。"); flagList.Add(-1);
        contentList.Add("“回溯到底是对已死之人的救赎还是二次伤害呢？”"); flagList.Add(2);
        contentList.Add("牛逼哄哄的猫使大人第一次对自己的工作产生了迷茫的情绪。"); flagList.Add(-1);
        contentList.Add("““不想了！完成工作送这小子上路就好！第二天兴许连他是谁都忘了，矫情个鬼！”"); flagList.Add(2);
    }
}
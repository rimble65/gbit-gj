using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HospitalManager : MonoBehaviour
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
    private float speed=70f;
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
        /*
        if (Time.time - timer <= interval+0.1f)
        {
            tips.SetActive(false);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cursor = currentContent.Length;
                tips.SetActive(true);
                content.text = currentContent.Substring(0, cursor);
                interval = -0.2f;
            }
            else if (cursor <= currentContent.Length)
            {
                cursor = (int)(Mathf.Min((Time.time - timer) / interval,1) * currentContent.Length);
                if (cursor == currentContent.Length)
                {
                    tips.SetActive(true);
                }
                content.text = currentContent.Substring(0, cursor);
            }
            
        }*/
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
                cursor = (int)(Mathf.Min(currentContent.Length, cursor + (Time.time-timer)*speed));
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
            SceneManager.LoadScene(1);
        }

    }
    private void AddContent()
    {
        contentList.Add("怎么回事？…你是刚刚的那只猫？"); flagList.Add(true);
        contentList.Add("什么叫‘那只猫’，一点也不尊重，我呢，就是帮你们这些可怜人类完成执念，回溯到执念所在的事件关键节点的-----"); flagList.Add(false);
        contentList.Add("伟大灵魂引路者·死神之镰的拥有者之一·升天路老司机·猫大人!"); flagList.Add(false);
        contentList.Add("唉，每天死一堆人类，还总有几个不乖乖上路的给我找事儿做，要不是看你年纪小，我才懒得管你!"); flagList.Add(false);
        contentList.Add("冒昧打扰…小猫，你刚刚说的执念、回溯是什么?"); flagList.Add(true);
        contentList.Add("说了叫我猫大人！你执念是什么,死都不肯死你心里没数吗？？"); flagList.Add(false);
        contentList.Add("回溯就是死神的恩赐啊，让你产生极大的执念那个人那件事，回到可以改变惨兮兮结局的节点啊，笨!"); flagList.Add(false);
        contentList.Add("那也就是说，我还可以见到她，可以告诉她…"); flagList.Add(true);
        contentList.Add("啊对对对，是这个理。这死神老儿越来越会变着法儿折磨人了emmm都不告诉我会看到些啥，一点心理准备都没有，到时候共情起来要被你小子折磨死…"); flagList.Add(false);
        contentList.Add("虽然还是没完全明白但…谢谢你，小猫"); flagList.Add(true);
        contentList.Add("…算了你爱咋叫咋叫吧，不过你可别以为啥也不做两手一摊，就能想干嘛干嘛了!"); flagList.Add(false);
        contentList.Add("每个死者会根据内心的执念和情感，只有通过了考验，集齐五瓣魂才能在平行时空改变结局!"); flagList.Add(false);


    }
}

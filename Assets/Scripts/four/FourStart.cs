using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FourStart : MonoBehaviour
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
        contentList.Add("时间这时候已经来到了一年半以后，高二下学期。"); flagList.Add(-1);
        contentList.Add("S班的同学们虽然看似都是两耳不闻窗外事的学霸，其实八卦的很，文艺委员和学习委员的“那点儿事”有时候就跟小说一样，更新一点，在他们嘴巴里就讨论一阵。"); flagList.Add(-1);
        contentList.Add("毕竟他们两总是泡在一起，关键是人家两人成绩还是挺好，你说气不气人。"); flagList.Add(-1);
        contentList.Add("“这才高二，这么早就做N大的自招题，你也不嫌脑袋装太多涨得慌”"); flagList.Add(3);
        contentList.Add("阿树自然地往浔的桌子上放下一个饭盒，打开之后，飘出浓浓的炒饭香。"); flagList.Add(-1);
        contentList.Add("“少打趣我，过会儿再吃，把这题做完，快了快了”"); flagList.Add(1);
        contentList.Add("“麻辣烫老板昨儿个才问我你是不是移情别恋了，都半个多月没赏光了”"); flagList.Add(3);
        contentList.Add("“但凡我能稳定在年级前十也不至于慌的跟猴一样，我这个年纪，是怎么能吃得下饭的！”"); flagList.Add(1);
        contentList.Add("话是这么说，她还是乖乖打开了饭盒，享受着眼前人每天早起给她忙活的成果。"); flagList.Add(-1);
        contentList.Add("“不过是一所大学而已，只是一段经历，不能决定人生的更多了，以你现在的水平，考个W大一点问题也没有，这样的退路已经是别人可望不可即的了，何必把自己逼太紧。”"); flagList.Add(3);
        contentList.Add("浔收起了平时的嬉皮笑脸，很认真地抬头道：“不可以，这不是别的什么...这是你的梦想，也是我的”"); flagList.Add(1);
        contentList.Add("阿树看到她眼睛里那份鲜少出现的认真，心脏又开始不听使唤地瞎跳了起来。"); flagList.Add(-1);
        contentList.Add("他只好先转移话题，来掩饰自己已经不太受控的心跳。"); flagList.Add(-1);
        contentList.Add("“对了，忘了告诉你，我最近通过街坊介绍，找到了一个非常便宜的房子，离地铁还特别近，就在xx站，上学的路程十分钟足够了”"); flagList.Add(3);
        contentList.Add("（皱眉）“街坊？有几个好东西？你是说那些曾经对你造成伤害、用言语中伤过你的人？”"); flagList.Add(1);
        contentList.Add("“那个街坊有个兄弟在工地干活，偶然听到不少工友都准备租xx路那的房子，我也去打探了的，700一个月，带水电，还可以给我妈挪个房住，我正好睡阁楼”"); flagList.Add(3);
        contentList.Add("“xx路的x小区？那个小区不是传闻要拆了改建吗？难怪租这么便宜，最后短租能捞几个月是几个月啊”"); flagList.Add(1);
        contentList.Add("“皱着眉头干嘛呢？我找到地方住了，过得好一点你不开心啊？”"); flagList.Add(3);
        contentList.Add("“怎么可能？我是觉得一室一厅，地段又好，还带水电，这个价钱怎么都不科学？不会是啥凶宅或者漏水发霉的房子吧？天啊想想就怕，要不你别住了，我帮你找房源？”"); flagList.Add(1);
        contentList.Add("“别闹了，捡大便宜的机会，我不可能放过的，周末拉我妈去跟房主谈，签了之后搬过去，上学省了不少事儿”"); flagList.Add(3);
        contentList.Add("浔还是皱着眉头，或许是女人的第六感，她感觉这个房子多少有点问题，可他们现在也不过是17岁的学生，对这些租房的注意事项、套路、合同、流程还不太了解。"); flagList.Add(-1);
        contentList.Add("“她的感觉是不是没有错...白血病...跟这个房子有关系对吗？本大人不懂你们人类那些丰富的死法，但是你的死跟这个房子一定有关系对不对？”"); flagList.Add(2);
        contentList.Add("“是…”"); flagList.Add(0);
        contentList.Add("“为什么？真的是凶宅？你被附身了，然后住了一年后就死了？”"); flagList.Add(2);
        contentList.Add("阿树像反应到了什么似的，骤然猛地抬起头，猫大人似乎从他眼里看到了一种很矛盾的景象——好像有一团燃烧着的火焰，以一发不可收的趋势逼近着本来平静无波的水面"); flagList.Add(-1);
        contentList.Add("不知道是原本平静的水面将这团火焰吞噬，还是这团火焰最终掀起星火燎原之势，把那一汪死水煮沸蒸发。"); flagList.Add(-1);
        contentList.Add("阿树的脸上浮现出了慌张、害怕的情绪。他已经死过了，但站在这个命运骤变的分叉口，他还是不可避免地恐惧着。"); flagList.Add(-1);
        contentList.Add("“猫大人，...下一个场景一定是我和我妈去租房那天...那天她先去了，我怕她又到处跑去接她...等到了她已经签了一年的合同...”"); flagList.Add(0);
        contentList.Add("“快些，快些，我要先去，比她先去”"); flagList.Add(0);
        contentList.Add("猫猫也神情凝重地跟着阿树进入了下一个溯回点，果然，是那个周末，原本的阿树还在书店的地上坐着做题。时间再度流动的那一刻，阿树飞快地合上了书，他一刻也没耽搁地飞跑着拦下了一辆出租车。"); flagList.Add(-1);
        contentList.Add("上车的那一刹那，他觉得前所未有的晕眩，这种体验是前几次回溯过程中都没有的，甚至感觉车在逆行，逆着车流渐渐远离他的目的地。"); flagList.Add(-1);
        contentList.Add("“阿树！等等...这样不行！”"); flagList.Add(2);
    }
}
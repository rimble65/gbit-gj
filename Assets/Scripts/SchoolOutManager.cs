using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SchoolOutManager : MonoBehaviour
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
    public GameObject classImg;
    private void Awake()
    {
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
            if (pageIndex == 12)
            {
                classImg.SetActive(true);
            }
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
        contentList.Add("初三下学期某一个寻常的午后，在大家都趴在教室里午睡时，性格孤僻的阿树拿出一本<color=red>《拜伦诗集》</color>从后门出去，站在走廊下借着正好的日光读了起来。");
        contentList.Add("浔拿着手机准备躲厕所里打游戏，她做贼似地一推门，却不想门外的走廊上有人");
        contentList.Add("也许是正午的日光太过刺眼——她眯起眼睛呆呆地看向那个瘦瘦高高的男孩");
        contentList.Add("阳光斜着打在他脸上，疏于打理而微显凌乱的刘海散乱地搭在额前，他眉眼低垂地目不转睛地看着书，纤长的眼睫毛打下小扇子般的阴影");
        contentList.Add("他白皙得过分的手上捧着那本<color=red>《拜伦诗集》</color>。这样一个人站在阳光里，实在是不知道是他夺走了这几米阳光，还是阳光青睐着他主动拥抱他。");
        contentList.Add("浔呆呆地看着这一幕，仿佛自己此时出一点声就是对这幅安静美好的画的打扰");
        contentList.Add("“有什么事吗”");
        contentList.Add("她点点头又摇摇头，攥着手机快速地跑掉了");
        contentList.Add("浔飞快地躲进厕所隔间，也顾不上许多——大口地喘起气来，脑子里却不禁回想起那个瘦弱的少年");
        contentList.Add("她略带焦急地锤着自己因短暂呼吸停滞又猛地加速跑后心跳紊乱的胸口，想把刚刚那一幕从自己的脑海中赶出去");
        contentList.Add("只是她不知道，这一幕在三年后，无数个三年后，无数个以后人生的普通得不能更普通的日子里，她都能清晰地回忆起来。");
        contentList.Add("浔以为自己过几个小时就会忘掉这种奇异的感觉");
        contentList.Add("可是她失算了，一个礼拜过去了，她的心头还是被那种奇异的感觉萦绕着，在升旗仪式上随意和阿树的对视，收作业时无意中碰到他的手，都能让她想入非非半天。");
        contentList.Add("她开始有意无意地关注这个稳坐第一宝座的少年");
        contentList.Add("她发现他写得一手清隽的好字；她发现明明没有在班上担任任何职务的他总是在值日的同学偷懒的时候悄悄帮忙做事");
        contentList.Add("她发现他时常捧着各类与考试无关的杂书看着，其中那本<color=red>《拜伦诗集》</color>也是她的心头爱。");
        contentList.Add("她开始关注这个少年为什么总是在放学铃打响的那一刹那就突然不见人影，她开始好奇他为什么总是在大家都在打牌、玩狼人杀的时候还在学习…");
        contentList.Add("就像无数个浪漫的爱情故事的开端那样，她发现她对他这份异于其他人的感情正在心中如种子般萌芽、生长、茂盛…");
        contentList.Add("“我在想…我喜欢上你了吧，阿树。”");


    }
}

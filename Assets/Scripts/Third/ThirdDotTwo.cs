using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ThirdDotTwo : MonoBehaviour
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
        SceneManager.LoadScene(10);
    }
    private void AddContent()
    {
        contentList.Add("“阿树，周测完了要一起去物外书店买书吗？”"); flagList.Add(1);
        contentList.Add("“你上周买了七八本，都看完了？”"); flagList.Add(3);
        contentList.Add("“看这棵灰色的树。天空通过它的纤维流入大地——大地狂饮后只留下一朵干瘪的云。被盗的宇宙拧入盘错的树根，拧成苍翠。”"); flagList.Add(1);
        contentList.Add("这短暂的自由瞬息溢出我们的躯体，旋转着穿过命运女神的血液前进"); flagList.Add(1);
        contentList.Add("“你不觉得这就是命运的指引吗？你看那麻辣烫摊子旁边那棵灰色的树，还有这种上了一下午课来吃麻辣烫的自由的感觉！啊，这就是自由溢出的感觉~我还要...”"); flagList.Add(1);
        contentList.Add("（慌忙打断）“快小点声，大街上发什么中二病呢，几个人回头看你呢”"); flagList.Add(3);
        contentList.Add("“你答应我去我就闭嘴！哎呀去不去嘛，去嘛去嘛”"); flagList.Add(1);
        contentList.Add("浔扯住了阿树的衣服"); flagList.Add(-1);
        contentList.Add("“去去去，祖宗，再扯口袋就要脱了”"); flagList.Add(0);
        contentList.Add("“诶，你这时候晚上不打工了吗？”"); flagList.Add(2);
        contentList.Add("“当时刚接到消息，我们这届出的新政策，调考排名百分之一的学生可以免赞助费入读高中部，很幸运地免除了六万的学费。”"); flagList.Add(0);
        contentList.Add("“那你日常生活费呢”"); flagList.Add(2);
        contentList.Add("“是小浔...找了个体面的理由，她说请我当家教，每周末给她补习两节化学课，然后一周给我400当做学费。”"); flagList.Add(0);
        contentList.Add("“这女孩子看着大大咧咧的，没想到心思这么细腻，她不能把钱这样直接塞到你手里，便想了这么一招。”"); flagList.Add(2);
        contentList.Add("“是啊，仅仅只是和她这么相处了两个月，一切都在不可思议地往好的方向发展，她永远能带给我快乐、鼓舞和惊喜...我那时就想，现在好好学习，以后多赚点钱，报答她，给她买喜欢的东西...”"); flagList.Add(0);
        contentList.Add("“她不会因为你没有给她买很多东西而怪你的，我想...她一定是更珍惜你们的情谊的”"); flagList.Add(2);
        contentList.Add("从书店出来后，浔抱着那本《特朗斯特罗姆诗歌全集》美滋滋地边跳边走，如果她有条尾巴，现在一定已经翘上天了。"); flagList.Add(-1);
        contentList.Add("“阿树啊，想想马上就要读高中了好开心啊”"); flagList.Add(1);
        contentList.Add("“嗯？这有什么开心的”"); flagList.Add(3);
        contentList.Add("“就是很开心啊，想到又可以跟你在一个教室里上课（突然想到了什么）啊不对...还不一定呢，你都签约了S班了，我才拿了个A约...”"); flagList.Add(2);
        contentList.Add("如果要跟你一个班，算上那种祖上积德的情况，中考要至少比我这次模考再前进200名...唉，老天爷能不能体谅一下我这个小学渣呀555"); flagList.Add(2);
        contentList.Add("“（被逗笑了）我们小浔什么时候成了个妄自菲薄的学渣了？你已经很棒了，只是人往往自己都看不清自己的潜能”"); flagList.Add(3);
        contentList.Add("你不应该在尘埃落定之前就自我否定，还有两个月的时间，只要把化学这个最跛脚的好好攻克，你一定能进S班的"); flagList.Add(3);
        contentList.Add("浔不知是惊讶还是惊喜得张着嘴巴看着阿树，慌忙把手机掏出来飞快打字。"); flagList.Add(-1);
        contentList.Add("“这是在干什么？”"); flagList.Add(3);
        contentList.Add("“我开心啊！！！你夸我诶，好好记下来，就冲你这话，我就是不睡觉了也要把化学考上90！不，100！”"); flagList.Add(1);
        contentList.Add("阿树被彻底逗笑了，这个脑回路神奇的女孩就像个开心果，在遇到她之后，从来不敢想的小确幸正一件件地发生在他真实的生活里。他惨淡苍白望如看不见光的漆黑走廊一般的人生基调骤然改编，就像一艘船偏离了原定的航道。"); flagList.Add(-1);
        contentList.Add("但他确认，这就是曾可望不可即的，从小从课本里学到的“快乐”和“幸福”。"); flagList.Add(-1);
        contentList.Add("他抬头看向夜空中镀了一层浅光的月亮，在两侧暖色路灯光的照射下，在他身边笑的正灿烂的少女就连影子都似乎被加上了柔光滤镜，也许是出于私心，他真的很想时间就这样停在这一刻，慢一点...再慢一点..."); flagList.Add(-1);
        contentList.Add("“我用什么才能留住你？”"); flagList.Add(3);
        contentList.Add("他也做起了这样有点“矫情”的附庸风雅的事，情不自禁地念出了浔最喜欢的博尔赫斯的《我用什么才能留住你》"); flagList.Add(-1);
        contentList.Add("“我给你萧索的街道、绝望的落日、荒郊的月亮。我给你一个久久仰望孤月之人的悲哀。”"); flagList.Add(1);
        contentList.Add("“我给你我的书中所能蕴含的一切悟力，以及我生活中所能有的男子气概和幽默。”"); flagList.Add(3);
        contentList.Add("“我给你一个从未有过信仰的人的忠诚。”"); flagList.Add(1);
        contentList.Add("我给你我设法保全的我自己的核心——不营字造句，不和梦交易，不被时间、欢乐和逆境触动的核心。"); flagList.Add(3);
        contentList.Add("我给你早在你出生前多年的一个傍晚看到的一朵黄玫瑰的记忆。"); flagList.Add(3);
        contentList.Add("我给你关于你生命的诠释，关于你自己的理论，你的真实而惊人的存在。"); flagList.Add(3);
        contentList.Add("我给你我的寂寞、我的黑暗、我心的饥渴；我试图用困惑、危险、失败来打动你。"); flagList.Add(3);
        contentList.Add("“我收回之前对你的讽刺，你小子书呆子浓度还没到百分百，还是有那么点浪漫细胞的”"); flagList.Add(2);
        contentList.Add("“那我谢谢您...”"); flagList.Add(0);
        contentList.Add("“这一段你有什么遗憾？我看这气氛好得很啊”"); flagList.Add(2);
        contentList.Add("“你不是人，你不明白”"); flagList.Add(0);
        contentList.Add("“怎么感觉你小子这话说的像骂人？？”"); flagList.Add(2);
    }
}
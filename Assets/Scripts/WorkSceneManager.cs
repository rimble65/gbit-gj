using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WorkSceneManager : MonoBehaviour
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
    public GameObject newBg;
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
            if (pageIndex == 7) newBg.SetActive(true);
            pageIndex++;
            currentContent = contentList[pageIndex];
            timer = Time.time;
            cursor = 0;
            tree.SetActive(flagList[pageIndex] == 3);
            maoMao.SetActive(flagList[pageIndex]==2);
            theTree.SetActive(flagList[pageIndex]==0);
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
        SceneManager.LoadScene(1);
    }
    private void AddContent()
    {
        contentList.Add("“铃————”放学铃响后，早就提前清好书包的浔脚底抹油一般挤过乌压压的回家大军"); flagList.Add(-1);
        contentList.Add("浔自以为特别谨慎地鬼鬼祟祟跟着阿树，两人就这样一前一后，拐了数个弯绕了几个巷，她与大步疾走的阿树始终保持着几米的距离"); flagList.Add(-1);
        contentList.Add("在浔彻底被绕晕之前，阿树终于在一家生意不错吵吵闹闹的大排档前停了下来"); flagList.Add(-1);
        contentList.Add("“等等，我有个问题…她这动静也不小啊，你当时是真没感觉到吗？”"); flagList.Add(2);
        contentList.Add("“当然知道，我想的是等到了地方、看到我做的事，她一定会识趣地离开。”"); flagList.Add(0);
        contentList.Add("（果不其然，阿树停顿了一会儿，不太耐烦地质问）“还要跟着我吗？你到底想干嘛？非要做跟踪这种既无聊又在违法犯罪边缘游走的事儿？”"); flagList.Add(3);
        contentList.Add("“不不不，你千万别误会，我没有恶意的，只是单纯地…额？关心同学？唉总之就是作为学习委员关心一下放学过于积极的同学嘛（或许是意识到自己找的理由很扯，声音越说越小）”"); flagList.Add(1);
        contentList.Add("“随便你”"); flagList.Add(3);
        contentList.Add("阿树径自走进大门，三拐两拐地走到了后厨，熟练地套上围裙，戴上皱巴巴扔在水池上的橡胶手套，端起一个木头凳子往满是泡沫的几大盆子碗碟旁一坐，埋着头就开始一个碗一个碟的接着洗。"); flagList.Add(-1);
        contentList.Add("（浔就站在他身后），浔之前也想过这个可能，只是当她心心念念的人真的坐在那不嫌脏不嫌累地干活时，她心里还是不太舒服。"); flagList.Add(-1);
        contentList.Add("少年洗得发白的校服领子、与同学们各类大牌格格不入的回力鞋、在食堂日复一日的夹几片肉配一点菜就着大碗白米饭的将就…在此时，这些行为和特征似乎都有了最好的注解。"); flagList.Add(-1);
        contentList.Add("阿树一回头，看到她拧巴的表情，似乎也感觉到了一丝不悦，声音不自觉地比之前和她每次表面友好的交流时还要低沉了几分，似乎是想到了什么，他缓缓抬起头，直视着浔的眼睛，扯出一个比哭还难看的笑容"); flagList.Add(-1);
        contentList.Add("“我爸死了，我妈天天喝酒，清醒的时候在喝酒，醉的时候瘫在家里骂骂咧咧，我家一个月领的低保是650块，我今晚做完这些，按日薪来算，可以拿到50块，这就是我的生活..”"); flagList.Add(3);
        contentList.Add("“或者说，这就是我活着的方式，你想和我做朋友？我可高攀不上浔小姐这种往游戏里一单单648充的眼睛都不眨的朋、友”"); flagList.Add(3);
        contentList.Add("浔愣住了，她张嘴想要说话，但是什么也说不出来。她心里被一种酸涩的情感充斥着，她想迈出的步子也似乎被定住了，两腿上好像被绑满了秤砣一般，寸步不得行。"); flagList.Add(-1);
        contentList.Add("阿树没有说话，但是他看她的眼神透露着满溢的嘲讽和陌生。"); flagList.Add(-1);
        contentList.Add("这样的结果在阿树意料之中，他平静地低下头，接着洗碗，气氛陷入一片死寂。"); flagList.Add(-1);
        contentList.Add("阿树以为浔已经离开了，突然浔一声不吭地蹲在地上，撸起袖子就去盆子里抓起一个碗，笨拙地搓洗着，这让阿树有点发怔。"); flagList.Add(-1);
        contentList.Add("两人就在诡异的沉默中洗完了五大盆的碗碟——当然主要是阿树洗的，浔洗碗的速度慢到令人发指。"); flagList.Add(-1);
        contentList.Add("阿树找老板汇报完情况时，看到的正是浔半靠在墙上捶腰的滑稽场面。他想说点什么，却也不知道怎么开口，一时间又陷入了诡异的沉默。"); flagList.Add(-1);
        contentList.Add("“阿树，你…你站住”"); flagList.Add(1);
        contentList.Add("“好”"); flagList.Add(3);
        contentList.Add("“我不知道你在想什么，我没有同情你的意思，我知道你不需要‘廉价’的同情，我只是很佩服你，我是真心想和你成为朋友的”"); flagList.Add(1);
        contentList.Add("“抱歉”"); flagList.Add(3);
        contentList.Add("“没关系。有些话…唉 我知道，可能现在的你听来实在觉得浅薄又无力，但是我还是想告诉你”"); flagList.Add(1);
        contentList.Add("“你说”"); flagList.Add(3);
        contentList.Add("“你也只有十五岁，却已经负担起了一个家，这是我…我们很多人都做不到的。你还一直是班上的第一名，你真的很厉害。”"); flagList.Add(1);
        contentList.Add("“我想和你做朋友，只是单纯地想多了解你一些、靠近你一点、单纯地被你吸引——”"); flagList.Add(1);
        contentList.Add("“我有什么吸引人的？”"); flagList.Add(3);
        contentList.Add("“很多很多啊！无论是在爱心节上毫不犹豫就捐出一百块的你，还是在升旗仪式上骄傲地握着红旗一角的你、努力学习抽空看诗集还能保持第一的你”"); flagList.Add(1);
        contentList.Add("“以及现在、就在刚刚我亲眼看到的为了生活而努力的你，都很吸引人啊！”"); flagList.Add(1);
        contentList.Add("omg,这小女孩激动得脸都红了"); flagList.Add(2);
        contentList.Add("浔一口气说完这些，她脸皮没那么薄，脸红是因为一口气上不来，喘的。"); flagList.Add(-1);
        contentList.Add("这次阿树彻底愣住了。他不知道怎么描述心里的感觉。"); flagList.Add(-1);
        contentList.Add("就好像从来都是孤零跨海漂泊的蜉蝣，此时被轻柔地托离了那深不见底的漩涡，就好像平静无波有着悲惨底色名为人生的白纸上，滴下了最鲜艳张扬的落墨。"); flagList.Add(-1);
        contentList.Add("他过去的十五年人生里，从来没有人对他说过“你很吸引人“，从小只有别人躲着他、欺负他、说他是被爸爸妈妈抛弃的孤儿。"); flagList.Add(-1);
        contentList.Add("可现在，这个女孩，就这样真真切切地站在他面前，认认真真地告诉他，他吸引她。"); flagList.Add(-1);
        contentList.Add("他感觉自己高筑耸栉的心理防线突然被击了个粉碎，他感受得到，浔眼中的急切、慌张、真诚不似作伪。"); flagList.Add(-1);
        contentList.Add("他突然觉得喉头酸酸的，他也只有十五岁，有的人这个年纪能在空调房里打打游戏做做题，享受着爸妈送进门的水果和零食。"); flagList.Add(-1);
        contentList.Add("可是他都没有，这些他都没有，他觉得他应该已经习惯了，可是现在清晰的这种酸涩和难过告诉他并不是不在意。"); flagList.Add(-1);
        contentList.Add("过去那么多苦难都熬过来了，被同学欺负、被亲戚嫌弃断了关系的时候、打着手电到处找自己醉酒不知道瘫在哪儿的母亲的时候"); flagList.Add(-1);
        contentList.Add("被学校书记明里暗里暗示高中部的赞助费是6万这笔他完全拿不出来的巨款的时候，他都没有哭。"); flagList.Add(-1);
        contentList.Add("可是现在，在这个纠缠他一个多礼拜，满眼都是他、说他吸引人、想和他做朋友的女孩面前，他居然绷不住地想哭。"); flagList.Add(-1);
        contentList.Add("“所以…你现在愿意答应做我的朋友了吗？”"); flagList.Add(1);
        contentList.Add("浔向阿树伸出了手。"); flagList.Add(-1);
        contentList.Add("阿树浅浅笑了，没有回答，像是不好意思一般很快地转过身。"); flagList.Add(-1);
        contentList.Add("“？？惊了个呆，就这？就这？我好歹能读取到你当时心里不说惊涛骇浪吧，至少也是大受触动吧...就不能好好理理人家吗？人类都是这么不坦率的生物吗？”"); flagList.Add(2);
        contentList.Add("“以前总觉得未来很长，很多事都可以慢慢来。往往就忽略了要及时表达些什么。”"); flagList.Add(0);
        contentList.Add("“可是你18岁就死了。”"); flagList.Add(2);
        contentList.Add("“是，你说得对，...这也就是我一直在自责、在后悔的原因。”"); flagList.Add(0);
        contentList.Add("“人总是错过了才会懊悔，失去才会珍惜。”"); flagList.Add(2);
        contentList.Add("“既然我有了再来一次的机会，就不会轻易放过了。”"); flagList.Add(0);
    }
}
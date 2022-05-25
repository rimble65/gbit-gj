using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FourDotTwo : MonoBehaviour
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
    public GameObject fourHun;
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
            if (pageIndex == contentList.Count - 2)
            {
                fourHun.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3f);
            }
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
        contentList.Add("一路偶有堵车，但是也算顺利，阿树却不知怎地全身汗透了，痛苦地紧揪着心脏，大口喘气着。"); flagList.Add(-1);
        contentList.Add("猫使毫不意外地看着那个从楼道里走出对着酒瓶直接吹的女人。"); flagList.Add(-1);
        contentList.Add("“妈？为什么....？你不是下午三点来吗？”"); flagList.Add(0);
        contentList.Add("“老娘没酒喝了出来买，你还管起你老娘了是吧？”"); flagList.Add(-1);
        contentList.Add("阿树不敢置信地看向猫使，他无法理解为什么这次回溯会是这样的结果。"); flagList.Add(-1);
        contentList.Add("猫使实在不知道怎么开口，他刚刚本来要开口要说的就是这个，但看到少年焦急的神情、那宛如抓住了最后一根救命稻草的神态，让他一个看惯了人类的生离死别的使者一时无言。"); flagList.Add(-1);
        contentList.Add("“我...唉，规则是这样的，尽管你们并不是什么都没付出地得到回溯，但影响到最终人物死因的节点，无论在哪个平行时空都不可逆。你的执念是她...可以改变和她有关的部分,但是你因此而死，这件事，不能改。”"); flagList.Add(2);
        contentList.Add("“前两天有个因没看好孩子导致孩子横穿马路被撞死的母亲，她回溯了五六遍，每一次都成功地从飞驰而来的车前救下了自己的一对儿女，但无论哪一次，她都不可避免地死在了车轮下。”"); flagList.Add(2);
        contentList.Add("“她救下了自己的儿女，却不能真的改变命运...她最后看到自己的儿女获救终于愿意转世，可她的灵魂在一次次不可逆的回溯中消耗了太多。。。注定她的转生路很痛苦”"); flagList.Add(2);
        contentList.Add("“阿树，你别犯傻！试多少次这一点都是改不了的...”"); flagList.Add(2);
        contentList.Add("可阿树置若罔闻，他一步步走向了那个满脸喜悦拿酒瓶的女人。双目赤红，他知道这些话说了没有用，可他还是抱着最后一丝期待看向自己的亲生母亲。"); flagList.Add(-1);
        contentList.Add("“妈，你知不知道...这房子甲醛严重超标，甲醛这种东西吸不得的...会得急性白血病...会死的”"); flagList.Add(0);
        contentList.Add("“矫情什么啊你？我看这房子好得很，老娘合同都签了，你要老娘反悔？你tm出钱违约？”"); flagList.Add(-1);
        contentList.Add("“你不懂甲醛是什么，我不怪你，可是我现在告诉你了，有害，不能住，是，你不会有事，我会死，死的是我！上次我没有注意到，自欺欺人地贪着小便宜，自欺欺人地告诉自己不会有事！可是结果呢！"); flagList.Add(0);
        contentList.Add("一年！这一年，我慢性地吸毒，慢慢地...我流鼻血的次数越来越多....一次次的晕眩、恶心、直到终于有一天胸像被刺穿了一样...醒来已经是在医院，他们说我得的是急性白血病。你知道这是什么病吗？因为自那以后我就没再见过你一次！你知道吗！”"); flagList.Add(0);
        contentList.Add("猫使看着这个从初见起就很清冷干净的男孩，此时如同一只疯狗，他几乎是咆哮着说出这些话，溢出的声音像嘶吼，也像呜咽。"); flagList.Add(-1);
        contentList.Add("那个女人打了他一巴掌。“你敢跟老娘扯着嗓子叫？”"); flagList.Add(-1);
        contentList.Add("她的第二巴掌很快也落了下来，却在半空中被阿树截住了。"); flagList.Add(-1);
        contentList.Add("妈，你生了我，我从生下来开始，没吃过几顿饱饭，永远活在害怕和别人的欺负、鄙视里，这十几年，我没拿过你的什么，我尽全力养着这个没有任何温情可言的家，我打几份工的钱你几顿酒就能喝完，然后我就去打更多的黑工。"); flagList.Add(0);
        contentList.Add("我不欠你什么了，这条命在从现在开始倒计时的一年后也会还给你。以后自己学个谋生的手艺吧，不会再有人养着你了。"); flagList.Add(0);
        contentList.Add("事到如今，短暂地重活了一遍，让他对眼前这个亲生母亲感到更加的陌生了。可从小对老天爷那一次次的质问和对命运不公的恨，在此时，却已经在心中翻不起什么波澜了。"); flagList.Add(-1);
        contentList.Add("他没有力气再去恨了，也没有必要，这次回溯，这个执念，是那个在他短短18年生命里带进唯一光亮的女孩给他的，他谁都不欠，只欠她一个亲口说出的答复，只缺那句话。"); flagList.Add(-1);
        contentList.Add("想到这里，他反而释然一般地放下手，转身一步步走向最终的结局。他无力改变这搞笑的命运，也不想再管这次回溯会造成什么后果和影响。。。"); flagList.Add(-1);
        contentList.Add("他只想给她一个答复，告诉她，她喜欢的人一直一直喜欢她，把她当作和看不到头的苦难斗争的唯一动力。"); flagList.Add(-1);
        contentList.Add("（迅速跟上了阿树，还在疑惑怎么第四瓣心魂并没有如期而至的时候，突然感觉手心一凉，一个有着裂纹的心魂落到了掌心）"); flagList.Add(2);
        contentList.Add("破裂的第四瓣，是在说明什么呢？"); flagList.Add(-1);
        
    }
}
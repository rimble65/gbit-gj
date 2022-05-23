using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FiveDotTwo : MonoBehaviour
{
    private Text content;
    //private TMP_Text content;
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
        //content = transform.Find("Dialog").Find("Text").GetComponent<TMP_Text>();
        content = transform.Find("Dialog").Find("Text").GetComponent<Text>();
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
        contentList.Add("（知道接下来要发生的事情，悄悄地退到旁边，庆幸自己还算是合格地完成了这次工作，刚刚忍住了差点把什么脱口而出的冲动）"); flagList.Add(2);
        contentList.Add("浔的脚步突然停住了，她转过身，坚定地朝着阿树走来。"); flagList.Add(-1);
        contentList.Add("阿树显然还没明白过来发生了什么。他还沉浸在这一幕里。"); flagList.Add(-1);
        contentList.Add("直到眼前人越走越近，丢开了那把黑伞，紧紧地抱住了他。"); flagList.Add(-1);
        contentList.Add("他感受到了女孩的体温，逐渐驱散了打在他身上的雨水的寒意。"); flagList.Add(-1);
        contentList.Add("浔松开了他，却是令他意外地笑笑。"); flagList.Add(-1);
        contentList.Add("“阿树，或者我应该叫你，来自未来的阿树”"); flagList.Add(1);
        contentList.Add("阿树只觉得自己这一瞬间全身的血液都凝固了。"); flagList.Add(-1);
        contentList.Add("他看向猫使，而刚刚退开的猫也正向他们走来。"); flagList.Add(-1);
        contentList.Add("他突然瞥见浔的胸口处，好像镶嵌着什么——"); flagList.Add(-1);
        contentList.Add("那是他回溯路上，收集到的完整的五瓣魂。"); flagList.Add(-1);
        contentList.Add("“很抱歉一开始隐瞒了你部分真相，不过这也是我工作的一部分。”"); flagList.Add(2);
        contentList.Add("“所谓放下，对于执念超载的普通人，是最难的事情，所以回溯的终局，是让你的【执念之人】明白你这份为了她回溯为了她以灵魂力量收集五瓣魂的真心和努力。”"); flagList.Add(2);
        contentList.Add("“至于放下，是她该先做的事，只有她知晓了前因后果，放下了，你才能放下。就好像得救的孩子，亲口承诺那位母亲‘我们会好好长大，妈妈请您不要再为我们担心’那样。”"); flagList.Add(2);
        contentList.Add("五瓣魂，是亡者的魂，它却束缚住了两个人。"); flagList.Add(-1);
        contentList.Add("一个该向前看，好好活着的人；一个走向往生，走向极乐，离开这个带给他十八年苦痛折磨的世界的人"); flagList.Add(-1);
        contentList.Add("回溯的过程在此之前仅仅像是一个人的奔赴，就好像孤身在人世间摸爬滚打那样，但是当五瓣魂完整重现的那一刻，这场双向的奔赴，在亡者生前没有机会开始的双向奔赴，才真正开始"); flagList.Add(-1);
        contentList.Add("“谢谢你，可爱的小猫，见到阿树，我真的很开心。”"); flagList.Add(1);
        contentList.Add("“（真心地笑了）不打扰你们了，这小子这一路也累坏了”"); flagList.Add(2);
        contentList.Add("“笨蛋阿树，你傻了吗，你说句话呀”"); flagList.Add(1);
        contentList.Add("“我从来没想过...我以为...我今天只是。。”"); flagList.Add(0);
        contentList.Add("他有些语无伦次了。"); flagList.Add(-1);
        contentList.Add("他一路凭着执念，为着那五瓣魂，为着和他心爱的女孩传递心意，剖白自己早就只为她而跳动的心。"); flagList.Add(-1);
        contentList.Add("他没奢求过能最后和她正式告别，他以为他会像一个过客一样仅仅只是掠过她本来漫长精彩的一生，自私地在这个本不该存在的空间宣告他的爱意，然后灰头土脸地从此不再和她有任何关系。"); flagList.Add(-1);
        contentList.Add("而平行时空的她想到“阿树”这个人时是因回忆起甜蜜而微笑还是因他的不告而别而心脏钝痛，都不再与死了的他有关。"); flagList.Add(-1);
        contentList.Add("可是现在她伸出手，牵住了他，紧紧地牵着。这场告别不是那么撕心裂肺。更像是久别的恋人打着伞在雨中就着微茫的月色漫步。"); flagList.Add(-1);
        contentList.Add("她手心的温度推翻了他之前所想的绝对谬误。"); flagList.Add(-1);
        contentList.Add("他紧紧回握住了她。"); flagList.Add(-1);
        contentList.Add("他们也不知道聊着什么，慢慢沿着湖边走着，说着，笑着，像之前很多个平常的日子那样。"); flagList.Add(-1);
        contentList.Add("猫使站在原地看着他们远去的年轻的背影，想了想还是跟了上去。"); flagList.Add(-1);
        contentList.Add("“你们等等我啊，等等本大人啊，我好歹是你们的大恩人吧！”"); flagList.Add(2);
        contentList.Add("我们也不知道他们那晚上说了什么，只知道两个人不知疲倦地聊了很多，约定了很多。"); flagList.Add(-1);
        contentList.Add("阿树会为着再与她遇见放下执念，而浔会精彩地活着，连同她优秀却又命途多舛的爱人的那份一起。"); flagList.Add(-1);

    }
}
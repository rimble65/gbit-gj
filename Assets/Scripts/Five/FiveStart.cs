using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FiveStart : MonoBehaviour
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
    private AudioController ac;
    public GameObject newbg;
    public GameObject newbg2;
    private void Awake()
    {
        ac = GameObject.Find("AudioSource").GetComponent<AudioController>();
        ac.PlayFiveJ();
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

            if (pageIndex == 14)
            {
                newbg.SetActive(true);
            }
            if (pageIndex == contentList.Count - 7)
            {
                newbg2.SetActive(true);
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
        contentList.Add("那是个平静的下午，班主任站在讲台上，语调平淡略有惋惜地说阿树同学因病休学。"); flagList.Add(-1);
        contentList.Add("浔一下课就去追问老师，他半个月没来学校了，是为什么，他生病了？生的什么病，他在哪，能不能去看看他。"); flagList.Add(-1);
        contentList.Add("老师告诉她他也不知道。"); flagList.Add(-1);
        contentList.Add("距离那个不太真实的下午已经过去了一年。时间转眼来到了高三。"); flagList.Add(-1);
        contentList.Add("一开始为阿树保留着的座位渐渐也堆满了试卷和资料，但大家除了这些也不会放别的，也不会在那里留下些其他的什么痕迹。"); flagList.Add(-1);
        contentList.Add("否则那个一直都是、至少一年以前都是嘻嘻哈哈、活泼开朗的文艺委员会十分“平淡”又不容拒绝地警告：“拿走”“不要乱碰别人的东西”"); flagList.Add(-1);
        contentList.Add("这一年浔不知道自己是怎么过来的，仿佛一切都不太真实，阿树突然消失，而消失的前一天他们还在为一些没有意义的小事争论半天又笑得人仰马翻。"); flagList.Add(-1);
        contentList.Add("她当然没有停止对阿树的信息轰炸，可是无论是发出的短信还是打出的电话，都石沉大海一般销声匿迹，没有任何回应。"); flagList.Add(-1);
        contentList.Add("她无数次地去过那个当时就让她耿耿于怀的房子，但不是吃了闭门羹就是看见阿树的妈坐在走廊上，眼神空洞地看着楼下。"); flagList.Add(-1);
        contentList.Add("终于到了这一天。"); flagList.Add(-1);
        contentList.Add("这个三年前她对他一见钟情、再难自拔的日子。"); flagList.Add(-1);
        contentList.Add("她和往常一样，上学，放学，就好像习惯了自己的生活已经少了一个人一般。"); flagList.Add(-1);
        contentList.Add("只是在早课结束的时候，她迟疑地拿出手机，给那个从未回过一条信息的号码发了一条短信。"); flagList.Add(-1);
        contentList.Add("“现在是五点半，六点滨江公园老地方见，我在那等你”"); flagList.Add(-1);
        contentList.Add("然后她平静地去和班长告了假，打了一辆车，直奔滨江公园。"); flagList.Add(-1);
        contentList.Add("她在滨江公园的划船售票处屋檐下躲雨，工作人员在九点半就已经提醒她赶快走了，现在是十点半，她手上有一把好心人留下的伞。"); flagList.Add(-1);
        contentList.Add("她还有什么呢？她看向那平静的水面，和停靠在岸边一艘艘的整齐的小船。那里还有他们一起度过的快乐日子的回忆。"); flagList.Add(-1);
        contentList.Add("但是她现在也不知道该怎样去缅怀这样一段回忆。为了一个冲动的念头，她在这足足站了四个多小时。"); flagList.Add(-1);
        contentList.Add("她最后深深地看了眼笼罩在黑夜下的湖面，撑开伞，转身欲走。"); flagList.Add(-1);
        contentList.Add("“啊啊啊走了走了！为什么啊，你有没有想过他看都没看到这条消息已经快咽气了啊”"); flagList.Add(2);
        contentList.Add("“这不怪她，这怎么能怪她呢。这一年我没有放弃求生，甚至超过了医生给我断定的最后半年的时间，如果一切按照希望的那样，这天本该是我骨髓移植的日子，只是，不太巧，移植不了了”"); flagList.Add(0);
        contentList.Add("“（当然知道移植不了是什么意思）那你为什么不至少联系她？哪怕回复一句消息也好啊，骗骗她自己有事，过段时间就回来了也好啊”"); flagList.Add(2);
        contentList.Add("“我不想再骗她。那时的我，满心想着活下来，成功地挺过去，再去找她。”"); flagList.Add(0);
        contentList.Add("（我该怎么告诉风华正茂正值青春的你，你喜欢的人马上就要死了，他还没有兑现给你的任何承诺，甚至连自己的心意都没有说出）"); flagList.Add(-1);
        contentList.Add("（这对于那个向阳花一般的人来说太残忍了）"); flagList.Add(-1);
        contentList.Add("“一年后，她没有去那所我们都想去的学校，读了一所同样很不错的学校，在这时知道了我的死讯，这样的结局，是我的执念，但又何尝不是她的结束和新的开始呢”"); flagList.Add(0);

    }
}
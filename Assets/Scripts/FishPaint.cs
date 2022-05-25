using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class FishPaint : MonoBehaviour
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
    private float speed = 70f;
    public GameObject mask;
    public int nextScene;
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

        if (cursor < currentContent.Length)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cursor = currentContent.Length;

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
         mask.SetActive(true);
         StartCoroutine(LoadNextScence());

    }
    IEnumerator LoadNextScence()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextScene);
    }
    private void AddContent()
    {
        contentList.Add("“快去吧，这次可要把握住机会，别给我再找活了。”"); flagList.Add(false);
    }
}
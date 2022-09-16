using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GroupControllerSec : MonoBehaviour
{
    public List<WordSec> words;
    public List<WordSec> falWords;
    public List<GameObject> imgList;
    public int index;
    public int nextScene;
    public GameObject thirdHun;
    private bool tipFlag = true;
    public GameObject tipPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tipFlag = !tipFlag;
            tipPanel.SetActive(tipFlag);
        }
    }
    private void Awake()
    {
        ResetWord();
    }

    public void CheckWin()
    {
        foreach (var item in words)
        {
            if (item.flag == false) return;
        }
        foreach (var item in falWords)
        {
            if (item.flag == true) return;
        }
        thirdHun.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3f).OnComplete(() =>
        {
            SceneManager.LoadScene(nextScene);
        });
        
        return;
    }

    public void ReStartGame()
    {
        ResetWord();

    }
    private void ResetWord()
    {
        for (int i = 1; i <= imgList.Count; i++)
        {
            string path = "第二关/未选中/images/" + index + "实例_";
            if (i < 10) path += "0" + i;
            else path += i.ToString();
            Sprite a = Resources.Load(path, typeof(Sprite)) as Sprite;
            imgList[i - 1].GetComponent<Image>().sprite = a;
        }
        foreach (var item in words)
        {
            item.flag = false;
        }
        foreach (var item in falWords)
        {
            item.flag = false;
        }
    }
}
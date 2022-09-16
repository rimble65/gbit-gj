using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MaomaoManager : MonoBehaviour
{
    public List<Button> buttons;
    public Dictionary<Image,bool> stringDic;
    public List<Image> images;
    public GameObject player;
    private Dictionary<Button, int> dic;
    private bool flag;
    private bool isMoving;
    public Image result;
    private Button preButton;
    public List<StringManager> stringList;
    public GameObject canvas;
    private AudioController ac;
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
        ac = GameObject.Find("AudioSource").GetComponent<AudioController>();
        ac.PlayTwoG();
        stringDic = new Dictionary<Image, bool>();
        dic = new Dictionary<Button, int>();
        InitDic();
    }
    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveListener(OnButtonClick);
        }
    }
    //字典和按钮的点击事件初始化
    private void InitDic()
    {
        for(int i = 0; i < images.Count; i++)
        {
            stringDic.Add(images[i], false);
        }
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.AddListener(OnButtonClick);
            dic.Add(buttons[i], i);
        }
    }
   
    private void OnButtonClick()
    {
        if (isMoving == true) return;
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        Button btn = currentButton.GetComponent<Button>();

        if (preButton == null)
        {
            preButton = btn;
        }
        else
        {
            bool isClose = IsClose(preButton, btn);
            if (isClose == false) return;
        }
        preButton = btn;
        if (!flag)
        {
            player.SetActive(true);
            player.transform.localPosition = currentButton.transform.localPosition;
            flag = true;
        }
        else
        {
            isMoving = true;
            player.transform.DOLocalMove(currentButton.transform.localPosition, 2f).OnComplete(()=>
            {
                isMoving = false;
                CheckGame();
            });
        }
    }
    //检查是否胜利
    private void CheckGame()
    {
        foreach (var item in stringDic)
        {

            if (item.Value == false)
            {
                return;
            }
        }
        Win();
    }
    //游戏胜利
    private void Win()
    {
        result.DOColor(new Color(1, 1, 1, 1), 3f).OnComplete(() =>
        {
            canvas.SetActive(true);
        });

    }
    //游戏失败
    public void GameOver()
    {
        player.gameObject.SetActive(false);
        flag = false;
        preButton = null;
        for(int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 1, 0);
        }
        for(int i = 0; i < stringDic.Count; i++)
        {
            stringDic[images[i]] = false;
            stringList[i].flag = false;
        }
    }

    private bool IsClose(Button btn1,Button btn2)
    {
        int pre = dic[btn1];
        int q = dic[btn2];
        switch (pre)
        {
            case 0:
                if ( q == 2 || q == 4) return true;
                else return false;
            case 1:
                if (q == 6 || q == 4) return true;
                else return false;
            case 2:
                if (q == 0 || q == 3) return true;
                else return false;
            case 3:
                if ( q == 2 || q == 4 || q==8 || q==7) return true;
                else return false;
            case 4:
                if (q == 1 || q == 0 || q == 3 || q==5) return true;
                else return false;
            case 5:
                if (q == 7 || q == 6 || q == 4|| q==9) return true;
                else return false;
            case 6:
                if (q == 1 || q == 5) return true;
                else return false;
            case 7:
                if (q == 3 || q == 5 || q == 8 || q==9) return true;
                else return false;
            case 8:
                if (q == 3 || q == 7 || q == 10) return true;
                else return false;
            case 9:
                if (q == 5 || q == 7 || q == 11) return true;
                else return false;
            case 10:
                if (q == 8 || q == 11) return true;
                else return false;
            case 11:
                if (q == 10 || q == 9) return true;
                else return false;
            default:
                break;
        }
        return false;
    }
}

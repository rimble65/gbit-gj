using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FishManager : MonoBehaviour
{
    public List<Button> buttons;
    public Dictionary<Image, bool> stringDic;
    public List<Image> images;
    public GameObject player;
    private Dictionary<Button, int> dic;
    private bool flag;
    private bool isMoving;
    public Image result;
    private Button preButton;
    public GameObject hint;
    public List<Bowl> bowlList;
    public Button restart;
    public List<FishStringManager> stringList;
    public GameObject canvas;
    public GameObject secondHun;
    private bool tipFlag = true;
    public GameObject tipPanel;

    private AudioSource audioSource;
    public AudioClip audioClip;
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
        audioSource = transform.GetComponent<AudioSource>();
        stringDic = new Dictionary<Image, bool>();
        dic = new Dictionary<Button, int>();
        InitDic();
        restart.onClick.AddListener(Restart);
    }
    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveListener(OnButtonClick);
        }
        restart.onClick.RemoveListener(Restart);
    }
    //字典和按钮的点击事件初始化
    private void InitDic()
    {
        for (int i = 0; i < images.Count; i++)
        {
            stringDic.Add(images[i], false);
        }
        for (int i = 0; i < buttons.Count; i++)
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
            player.transform.DOLocalMove(currentButton.transform.localPosition, 2f).OnComplete(() =>
            {
                isMoving = false;
                CheckGame();
            });
        }
    }
    //检查是否胜利
    private void CheckGame()
    {
        foreach (var item in stringList)
        {

            if (item.flag == false)
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
            audioSource.PlayOneShot(audioClip);
            secondHun.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3f).OnComplete(()=>
            {
                result.color = new Color(1, 1, 1, 0);
                canvas.SetActive(true);
            });

        });
    }
    //游戏失败
    public void GameOver()
    {
        hint.SetActive(true);
    }
    public void Restart()
    {
        hint.SetActive(false);
        player.gameObject.SetActive(false);
        flag = false;
        preButton = null;
        for (int i = 0; i < bowlList.Count; i++)
        {
            bowlList[i].InitPos();
        }
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < images.Count; i++)
        {
            stringDic[images[i]] = false;
            stringList[i].flag = false;
        }
    }

    private bool IsClose(Button btn1, Button btn2)
    {
        int pre = dic[btn1];
        int q = dic[btn2];
        switch (pre)
        {
            case 0:
                if (q == 1 || q == 5) return true;
                else return false;
            case 1:
                if (q == 0 || q == 2 || q == 5 || q == 6) return true;
                else return false;
            case 2:
                if (q == 3 || q == 1 || q == 4 || q == 6) return true;
                else return false;
            case 3:
                if (q == 2 || q == 4 || q == 7) return true;
                else return false;
            case 4:
                if (q == 2 || q == 3 || q == 6 || q == 7) return true;
                else return false;
            case 5:
                if (q == 0 || q == 1 || q == 9 || q ==10) return true;
                else return false;
            case 6:
                if (q == 1 || q == 4 || q == 2 || q == 8 || q ==10 || q ==11) return true;
                else return false;
            case 7:
                if (q == 3 || q == 4 || q ==8 || q ==12) return true;
                else return false;
            case 8:
                if (q == 7 || q == 6 || q == 11 || q ==12) return true;
                else return false;
            case 9:
                if (q == 5 || q == 10 ) return true;
                else return false;
            case 10:
                if (q == 5 || q == 6 || q == 11 || q == 9) return true;
                else return false;
            case 11:
                if (q == 8 || q == 6 || q == 10 || q == 12) return true;
                else return false;
            case 12:
                if (q == 7 || q == 8 || q == 11 ) return true;
                else return false;
            default:
                break;
        }
        return false;
    }
}

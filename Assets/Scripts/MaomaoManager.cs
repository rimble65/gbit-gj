using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MaomaoManager : MonoBehaviour
{
    public List<Button> buttons;
    public Dictionary<Image,bool> stringDic;
    public List<Image> images;
    public GameObject player;
    private Dictionary<Button, bool> dic;
    private bool flag;
    private bool isMoving;

    private void Awake()
    {
        stringDic = new Dictionary<Image, bool>();
        dic = new Dictionary<Button, bool>();
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
        }
    }
   
    private void OnButtonClick()
    {
        if (isMoving == true) return;
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        Button btn = currentButton.GetComponent<Button>();
        dic[btn] = true;
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
        Debug.Log("Win");
    }
    //游戏失败
    public void GameOver()
    {
        player.transform.localPosition = new Vector3(-500, 0, 0);
        for(int i = 0; i < dic.Count; i++)
        {
            dic[buttons[i]] = false;
        }
        for(int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 1, 0);
        }
        for(int i = 0; i < stringDic.Count; i++)
        {
            stringDic[images[i]] = false;
        }
    }

}

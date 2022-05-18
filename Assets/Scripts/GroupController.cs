using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupController : MonoBehaviour
{
    public List<Word> words;
    public List<Word> falWords;
    public List<GameObject> imgList;
    public int index;

    private void Awake()
    {
        for(int i = 1; i <= imgList.Count; i++)
        {
            string path = "第一关/未选中/images/" + index + "示例_";
            if (i < 10) path += "0" + i;
            else path+= i.ToString();
            Sprite a= Resources.Load(path,typeof(Sprite)) as Sprite;
            imgList[i - 1].GetComponent<Image>().sprite = a;
        }
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
        Debug.Log("win");
        return;
    }
}

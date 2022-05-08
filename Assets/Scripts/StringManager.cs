using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StringManager : MonoBehaviour
{
    private bool flag;
    private MaomaoManager manager;
    private Image img;
    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<MaomaoManager>();
        img = transform.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag == true)
        {
            manager.GameOver();
            return;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            flag = true;
            Image img = transform.GetComponent<Image>();
            img.DOColor(new Color(1, 1, 1, 1), 1f);
            manager.stringDic[img] = true;
        }
    }
}

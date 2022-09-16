using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    private bool isEnter;
    public bool flag;
    private GroupController gc;
    private void Awake()
    {
        gc = GetComponentInParent<GroupController>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isEnter)
        {
            Sprite a = transform.GetComponent<Image>().sprite;
            string path = a.ToString();
            if (path[1] != '示')
            {
                string tmp = path.Substring(path.Length - 23, 2);
                path = "第一关/未选中/images/2示例_" + tmp;
                transform.GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                flag = false;
            }
            else
            {

                string tmp = path.Substring(path.Length - 23, 2);

                path = "第一关/已选中/images/2-22_" + tmp;

                transform.GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;

                flag = true;
            }
            gc.CheckWin();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isEnter = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnter = false;
    }
}

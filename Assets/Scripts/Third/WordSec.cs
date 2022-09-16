using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSec : MonoBehaviour
{
    public bool flag;
    private GroupControllerSec gc;
    private bool isEnter;
    private void Awake()
    {
        gc = GetComponentInParent<GroupControllerSec>();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isEnter)
        {
            Sprite a = transform.GetComponent<Image>().sprite;
            string path = a.ToString();
            if (path[1] != '实')
            {
                string tmp = path.Substring(path.Length - 23, 2);
                path = "第二关/未选中/images/1实例_" + tmp;
                transform.GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                flag = false;
            }
            else
            {

                string tmp = path.Substring(path.Length - 23, 2);

                path = "第二关/已选中/images/1-22_" + tmp;

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
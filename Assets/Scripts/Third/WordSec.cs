using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSec : MonoBehaviour
{
    private float timer;
    private float interval = 0.05f;
    public bool flag;
    private GroupControllerSec gc;
    private void Awake()
    {
        gc = GetComponentInParent<GroupControllerSec>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (timer == 0 || Time.time - timer > interval)
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
                timer = Time.time;
                gc.CheckWin();
            }

        }
    }
}
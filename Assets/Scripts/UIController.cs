using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private bool flag=true;
    public GameObject EscPanel;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            flag = !flag;
            if (flag == false)
            {
                Time.timeScale = 0;
                EscPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                EscPanel.SetActive(false);
            }
            

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private bool flag=true;
    public GameObject EscPanel;
    public GameObject QuitPanel;
    public GameObject setPanel;
    public GameObject mainPanel;
    public GameObject testPanel;
    public GameObject savePanel;
    public GameObject choosePanel;
    private string path;
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;

    public Slider slider;
    public AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (PlayerPrefs.HasKey("first"))
        {
            img1.sprite = Resources.Load("mao/病房", typeof(Sprite)) as Sprite;
        }
        if (PlayerPrefs.HasKey("second"))
        {
            img2.sprite = Resources.Load("mao/教室", typeof(Sprite)) as Sprite;
        }
        if (PlayerPrefs.HasKey("third"))
        {
            img3.sprite = Resources.Load("mao/街道", typeof(Sprite)) as Sprite;
        }
        if (PlayerPrefs.HasKey("four"))
        {
            img4.sprite = Resources.Load("mao/bg", typeof(Sprite)) as Sprite;
        }
    }
    private void Update()
    {
        audioSource.volume = slider.value;
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
                QuitPanel.SetActive(false);
                setPanel.SetActive(false);
                testPanel.SetActive(false);
                savePanel.SetActive(false);
                choosePanel.SetActive(false);
            }
            

        }
    }
    public void OnBackClick()
    {
        flag = true;
        Time.timeScale = 1;
        EscPanel.SetActive(false);
        QuitPanel.SetActive(false);
        setPanel.SetActive(false);
        testPanel.SetActive(false);
        savePanel.SetActive(false);
        choosePanel.SetActive(false);
    }
    public void OnQuitClick()
    {
        QuitPanel.SetActive(true);
    }
    public void QuitNo()
    {
        QuitPanel.SetActive(false);

    }
    public void QuitYes()
    {
        Application.Quit();
    }

    public void OnSetClick()
    {
        setPanel.SetActive(true);
    }
    public void OnSetBackClick()
    {
        setPanel.SetActive(false);
    }

    public void HideMainPanel()
    {
        mainPanel.SetActive(false);
    }
    public void TestPanel()
    {
        testPanel.SetActive(true);
    }
    public void ShowSavepanel()
    {
        savePanel.SetActive(true);
    }
    public void HideSavePanel()
    {
        savePanel.SetActive(false);
    }
    public void ShowChoosePanel1()
    {
        path = "first";
        choosePanel.SetActive(true);
    }
    public void ShowChoosePanel2()
    {
        path = "second";
        choosePanel.SetActive(true);
    }
    public void ShowChoosePanel3()
    {
        path = "third";
        choosePanel.SetActive(true);
    }
    public void ShowChoosePanel4()
    {
        path = "four";
        choosePanel.SetActive(true);
    }
    public void HideChoosePanel()
    {
        choosePanel.SetActive(false);
    }

    public void SaveGameFir()
    {
        int index1 = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("first", index1);
        img1.sprite = Resources.Load("mao/病房", typeof(Sprite)) as Sprite;
    }
    public void SaveGameSec()
    {
        int index2 = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("second", index2);
        img2.sprite = Resources.Load("mao/教室", typeof(Sprite)) as Sprite;
    }
    public void SaveGameThird()
    {
        int index3 = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("third", index3);
        img3.sprite = Resources.Load("mao/街道", typeof(Sprite)) as Sprite;
    }
    public void SaveGameFour()
    {
        int index4 = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("four", index4);
        img4.sprite = Resources.Load("mao/bg", typeof(Sprite)) as Sprite;
    }

    public void LoadGameFir()
    {
        int index1 = PlayerPrefs.GetInt("first");
        SceneManager.LoadScene(index1);
    }
    public void LoadGameSec()
    {
        int index2 = PlayerPrefs.GetInt("second");
        SceneManager.LoadScene(index2);
    }
    public void LoadGameThird()
    {
        int index3 = PlayerPrefs.GetInt("third");
        SceneManager.LoadScene(index3);
    }
    public void LoadGameFour()
    {
        int index4 = PlayerPrefs.GetInt("four");
        SceneManager.LoadScene(index4);
    }

    public void SaveButton()
    {
        if (path == "first")
        {
            SaveGameFir();
        }
        else if (path == "second")
        {
            SaveGameSec();
        }
        else if (path == "third")
        {
            SaveGameThird();
        }
        else if (path == "four")
        {
            SaveGameFour();
        }
        choosePanel.SetActive(false);
    }
    public void  LoadButton()
    {
        if (path == "first")
        {
            LoadGameFir();
        }
        else if (path == "second")
        {
            LoadGameSec();
        }
        else if (path == "third")
        {
            LoadGameThird();
        }
        else if (path == "four")
        {
            LoadGameFour();
        }
        EscPanel.SetActive(false);
        QuitPanel.SetActive(false);
        setPanel.SetActive(false);
        testPanel.SetActive(false);
        savePanel.SetActive(false);
        choosePanel.SetActive(false);

    }
}

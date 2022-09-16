using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 initPos;
    public GameObject endPos;
    private bool flag;//true 不动 false dong
    public GameObject player;
    private float distance;
    public GameObject losePanel;
    public int nextScene;
    private AudioController ac;
    private bool tipFlag = true;
    public GameObject tipPanel;
    public AudioClip audioClip;
    private void Awake()
    {
        ac = GameObject.Find("AudioSource").GetComponent<AudioController>();
        ac.PlayFouG();
        initPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tipFlag = !tipFlag;
            tipPanel.SetActive(tipFlag);
        }
        if (tipFlag == false) Move();
        if (CheckDistance() == false)
        {
            GameOver();
        }
    }
    private void Move()
    {
        Vector3 startPositon = transform.position;
        Vector3 endPosition = endPos.transform.position;
        float dis = Vector3.Distance(startPositon, endPosition);
        transform.position = Vector3.Lerp(startPositon, endPosition, 1 / dis * Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, endPosition) <= 1f)
        {
            transform.position = endPosition;
        }
    }
    public void ReStartGames()
    {
        losePanel.SetActive(false);
        player.GetComponent<PlayerJump>().ReStart();
        transform.position = initPos;
        Time.timeScale = 1;
    }
    public bool CheckDistance()
    {
        distance = transform.position.x - player.transform.position.x;
        Debug.Log(distance);
        if (distance > 21)
        {
            return false;
        }
        return true;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
    public void WinGame()
    {  
        SceneManager.LoadScene(nextScene);
        
    }
}

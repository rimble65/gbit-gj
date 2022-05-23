using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 initPos;
    public GameObject endPos;
    private bool flag;//true 移动到目的地了 false 还没有
    public GameObject player;
    private float distance;
    public GameObject losePanel;
    private void Awake()
    {
        initPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false) Move();
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
            flag = true;
            WinGame();
        }
    }
    public void ReStartGames()
    {
        transform.position = initPos;
        flag = false;
        Time.timeScale = 1;
    }
    public bool CheckDistance()
    {
        distance = transform.position.x - player.transform.position.x;
        Debug.Log(distance);
        if (distance > 19)
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
        SceneManager.LoadScene(15);
    }
}

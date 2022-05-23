using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CubeMap : MonoBehaviour
{
    public List<GameObject> boxList;
    public GameObject player;
    private float y = 0;
    public float rotateSpeed = 0;
    // Start is called before the first frame update
    private bool tipsFlag;
    public int index;
    public GameObject mask;
    public List<bool> isBook;
    public GameObject bg;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TurnCubeLeft();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TurnCubeRight();
        }
    }

    public void TurnCubeLeft()
    {
        index++;
        if (index > 3) index = 0;
        if (isBook[index] == false)
        {
            ShowMask();
        }
        else
        {
            HideMask();
        }
        y += 90;
        transform.DOLocalRotate(new Vector3(0, y, 0), rotateSpeed);
        StartCoroutine(HideSide());
        player.transform.DOLocalMoveX(player.transform.localPosition.x - 10,rotateSpeed);
    }
    public void TurnCubeRight()
    {

        index--;
        if (index < 0) index = 3;
        if (isBook[index] == false)
        {
            ShowMask();
        }
        else
        {
            HideMask();
        }
        StartCoroutine(HideSide());
        y -= 90;
        transform.DOLocalRotate(new Vector3(0, y, 0), rotateSpeed);
        player.transform.DOLocalMoveX(player.transform.localPosition.x + 10, rotateSpeed);
    }
    IEnumerator HideSide()
    {
        yield return new WaitForSeconds(.8f);
        HideOtherSide(index);
    }
    private void HideOtherSide(int index)
    {
        if (index == 0)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
            boxList[0].SetActive(true);
            boxList[1].SetActive(true);
            boxList[2].SetActive(false);
            boxList[3].SetActive(true);
        }
        else if (index == 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.5f);
            boxList[0].SetActive(true);
            boxList[1].SetActive(true);
            boxList[2].SetActive(true);
            boxList[3].SetActive(false);
        }
        else if (index == 2)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0); 
            boxList[0].SetActive(false);
            boxList[1].SetActive(true);
            boxList[2].SetActive(true);
            boxList[3].SetActive(true);
        }
        else
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.5f);
            boxList[0].SetActive(true);
            boxList[1].SetActive(false);
            boxList[2].SetActive(true);
            boxList[3].SetActive(true);
        }
    }
    public void HideMask()
    {
        mask.SetActive(false);
    }
    public void ShowMask()
    {
        mask.SetActive(true);
    }

    public void CheckGame()
    {
        foreach (var item in isBook)
        {
            if (item == false) return;
        }
        Win();
    }
    private void Win()
    {
        bg.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    public List<GameObject> boxList;
    public Animator ani;
    public GameObject player;
    private float y = 0;
    public float rotateSpeed = 0;
    // Start is called before the first frame update
    private bool tipsFlag;
    public int index;
    public GameObject mask;
    public List<bool> isBook;
    public GameObject bg;
    public GameObject firstHun;
    public AudioController ac;
    private bool tipFlag = true;
    public GameObject tipPanel;

    public AudioSource audioSource;
    public AudioClip audioClip;
    private void Awake()
    {
        ac = GameObject.Find("AudioSource").GetComponent<AudioController>();
        ac.PlayFirG();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tipFlag = !tipFlag;
            tipPanel.SetActive(tipFlag);
        }
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
        player.gameObject.SetActive(false);
        index++;

        if (index > 3) index = 0;
        AniTurn();
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
        StartCoroutine(PlayerMoveRight());
        //player.transform.DOLocalMoveX(player.transform.localPosition.x - 10,rotateSpeed);
        
    }
    public void TurnCubeRight()
    {
        player.gameObject.SetActive(false);
        index--;
        
        if (index < 0) index = 3;
        AniTurn();
        if (isBook[index] == false)
        {
            ShowMask();
        }
        else
        {
            HideMask();
        }
        StartCoroutine(HideSide());
        StartCoroutine(PlayerMoveLeft());
        y -= 90;
        transform.DOLocalRotate(new Vector3(0, y, 0), rotateSpeed);
        //player.transform.DOLocalMoveX(player.transform.localPosition.x + 10, rotateSpeed);
        
    }
    IEnumerator PlayerMoveRight()
    {
        yield return new WaitForSeconds(.8f);
        player.transform.localPosition = new Vector3(player.transform.localPosition.x - 9.5f, player.transform.localPosition.y, player.transform.localPosition.z);
        player.gameObject.SetActive(true);
        AniTurn();
    }
    IEnumerator PlayerMoveLeft()
    {
        yield return new WaitForSeconds(.8f);
        player.transform.localPosition = new Vector3(player.transform.localPosition.x + 9.5f, player.transform.localPosition.y, player.transform.localPosition.z);
        player.gameObject.SetActive(true);
        AniTurn();
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
        AniTurn();
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
        audioSource.PlayOneShot(audioClip);
        firstHun.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3f).OnComplete(() =>
        {
            
            bg.SetActive(true);
        });
        
    }
    private void AniTurn()
    {
        if (index == 0)
        {
            
            ani.SetBool("fir",true);
            ani.SetBool("sec", false);
            ani.SetBool("third", false);
            ani.SetBool("four", false);
        }
        else if (index == 1)
        {
            ani.SetBool("sec", true);
            ani.SetBool("fir", false);
            ani.SetBool("third", false);
            ani.SetBool("four", false);
        }
        else if (index == 2)
        {
            ani.SetBool("third", true);
            ani.SetBool("sec", false);
            ani.SetBool("fir", false);
            ani.SetBool("four", false);
        }
        else if (index == 3)
        {
            ani.SetBool("four", true);
            ani.SetBool("sec", false);
            ani.SetBool("third", false);
            ani.SetBool("fir", false);
        }
    }
}

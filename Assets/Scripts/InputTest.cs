using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InputTest : MonoBehaviour
{
    private void Awake()
    {
        transform.GetComponent<InputField>().onEndEdit.AddListener(EndValue);
    }


    private void EndValue(string value)
    {
        int index = 0;
        if (value.Length == 1)
        {
            index = value[0] - '0';
        }
        else if (value.Length == 2)
        {
            index = (value[0] - '0') * 10 + (value[1] - '0');
        }
        else
        {
            return;
        }
        if(index>0 && index <= 21)
        {
            transform.gameObject.SetActive(false);
            SceneManager.LoadScene(index);
        }
    }
}

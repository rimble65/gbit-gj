using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp : MonoBehaviour
{
    public CameraController cc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cc.GameOver();
    }
}

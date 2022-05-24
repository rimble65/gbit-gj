using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : MonoBehaviour
{
    public CubeMap cm;
    private float interval=2f;
    private float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(timer==0 || Time.time - timer > interval)
        {
            cm.TurnCubeRight();
            timer = Time.time;
            Debug.Log(1);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject mask;
    private CubeMap cubeMap;
    private void Awake()
    {
        cubeMap = GameObject.Find("CubeMap").GetComponent<CubeMap>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cubeMap.isBook[cubeMap.index] = true;
        mask.SetActive(false);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firJ;
    public AudioClip firG;
    public AudioClip twoj;
    public AudioClip twog;
    public AudioClip thij;
    public AudioClip thig;
    public AudioClip fouj;
    public AudioClip foug;
    public AudioClip fivj;
    public AudioClip fivg;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void PlayFirJ()
    {
        audioSource.clip = firJ;
        audioSource.Play();
    }
    public void PlayFirG()
    {
        audioSource.clip = firG;
        audioSource.Play();
    }
    public void PlayTwoJ()
    {
        audioSource.clip = twoj;
        audioSource.Play();
    }
    public void PlayTwoG()
    {
        audioSource.clip = twog;
        audioSource.Play();
    }
    public void PlayThiJ()
    {
        audioSource.clip = thij;
        audioSource.Play();
    }
    public void PlayThiG()
    {
        audioSource.clip = thig;
        audioSource.Play();
    }
    public void PlayFouJ()
    {
        audioSource.clip = fouj;
        audioSource.Play();
    }
    public void PlayFouG()
    {
        audioSource.clip = foug;
        audioSource.Play();
    }
    public void PlayFiveJ()
    {
        audioSource.clip = fivj;
        audioSource.Play();
    }
    public void PlayFiveG()
    {
        audioSource.clip = fivg;
        audioSource.Play();
    }
}

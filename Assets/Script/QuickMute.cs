using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMute : MonoBehaviour
{
    public GameObject MuteBut;
    public GameObject UnMuteBut;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UnMuteBut.SetActive(false);
        MuteBut.SetActive(true);
    }

    public void Mute()
    {
        audioSource.volume = 0;
        UnMuteBut.SetActive(true);
        MuteBut.SetActive(false);
    }
    public void UnMute()
    {
        audioSource.volume = 0.5f;
        UnMuteBut.SetActive(false);
        MuteBut.SetActive(true);
    }

}

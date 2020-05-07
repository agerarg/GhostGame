using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManage : MonoBehaviour
{
    public GameObject DoorClosed;
    public GameObject DoorOpen;
    AudioSource audioSource;
    void Start()
    {
        CloseTheDoor();
        audioSource = GetComponent<AudioSource>();
    }
    void OpenTheDoor()
    {
        audioSource.Play();
        DoorClosed.SetActive(false);
        DoorOpen.SetActive(true);
    }
    void CloseTheDoor()
    {
        DoorClosed.SetActive(true);
        DoorOpen.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Enemy")
        {
            OpenTheDoor();
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Enemy")
        {
            CloseTheDoor();
        }
    }
}

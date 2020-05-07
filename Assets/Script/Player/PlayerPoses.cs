using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoses : MonoBehaviour, IRoomSet
{
    public GameObject MyBody;
    public int room = 0;
    private TriggerObject possesedObject;
    private bool thingIsPosses=false;
    private bool isAlreadySacredRecently = false;
    private float scareSpamStop = 0;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MyBody.SetActive(true);
    }
    public void setRoom(int num)
    {
        room = num;
    }
    public void MakeSound()
    {
        if(possesedObject != null)
        {
            possesedObject.Sound();
            possesedObject.roomBelong.AtractIfSomeoneThere();
        }
    }
    public void MakeSpooke()
    {
        if (possesedObject != null)
        {
            possesedObject.Spooke();
            possesedObject.roomBelong.GtfoFromThere();
        }
    }
    public void MakeScare()
    {
        if (!isAlreadySacredRecently)
        {
            scareSpamStop = 3f;
            isAlreadySacredRecently = true;
            if (possesedObject != null)
            {
                possesedObject.Scare();
                possesedObject.roomBelong.Scare();
            }
        }
    }
    public bool PossesOject(PlayerMovement player, TriggerObject obj)
    {
        if (!thingIsPosses)
        {
            player.AllowMoving(false);
            player.PossesionCooldown();

           player.SetPositionTo(obj.ObjectPosition());
            audioSource.Play();
            possesedObject = obj;
            MyBody.SetActive(false);
            obj.Posses();
            thingIsPosses = true;
            WindowManager.instance.SetPossessionOptions(true, obj.ObjectPosition());
            return true;
        }

        return false;
    }
    public void StopPosses()
    {
        MyBody.SetActive(true);
        if(possesedObject!=null)
          possesedObject.DesPosses();
        Debug.Log("Player quit of possesing!");
        thingIsPosses = false;
        possesedObject = null;
        WindowManager.instance.SetPossessionOptions(false , new Vector3(0,0,0));
    }
  void Update()
    {
        if(isAlreadySacredRecently)
        {
            scareSpamStop -= Time.deltaTime;
            if (scareSpamStop <= 0)
                isAlreadySacredRecently = false;
        }
    }
}

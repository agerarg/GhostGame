using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoses : MonoBehaviour
{
    public GameObject MyBody;
    private TriggerObject possesedObject;
    private bool thingIsPosses=false;
    void Start()
    {
        MyBody.SetActive(true);
    }

    public void MakeSound()
    {
        if(possesedObject != null)
        {
            possesedObject.Sound();
        }
    }
    public void MakeSpooke()
    {
        if (possesedObject != null)
        {
            possesedObject.Spooke();
        }
    }
    public void MakeScare()
    {
        if (possesedObject != null)
        {
            possesedObject.Scare();
        }
    }
    public bool PossesOject(PlayerMovement player, TriggerObject obj)
    {
        if (!thingIsPosses)
        {
            player.AllowMoving(false);
            player.PossesionCooldown();

           player.SetPositionTo(obj.ObjectPosition());

            possesedObject = obj;
            MyBody.SetActive(false);
            obj.Posses();
            thingIsPosses = true;
            Debug.Log("Posses Succed");
            WindowManager.instance.SetPossessionOptions(true);
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
        WindowManager.instance.SetPossessionOptions(false);
    }
    
}

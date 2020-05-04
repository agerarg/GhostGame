using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private bool isPosses = false;

    private Vector3 originPosition;
    private Quaternion originRotation;
    private float shake_decay = 0.002f;
    private float temp_shake_intensity = 0;

    public Vector3 ObjectPosition()
    {
        return transform.position;
    }

    public void Spooke()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = 0.1f;
    }
    public void Sound()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = 0.1f;
    }
    public void Scare()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = 0.3f;
    }
    void Update()
    {
       if(isPosses)
        {
            if (temp_shake_intensity > 0)
            {
                transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
                transform.rotation = new Quaternion(
                    originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                    originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                    originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                    originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
                temp_shake_intensity -= shake_decay;
            }
        }
    }
    public void Posses()
    {
        isPosses = true;
    }
    public void DesPosses()
    {
        isPosses = false;
        Debug.Log("Obj Despossesed!");
    }
    void OnMouseDown()
    {
        if (!isPosses)
        {
            PlayerMovement player = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));

            PlayerPoses playerPos = (PlayerPoses)FindObjectOfType(typeof(PlayerPoses));
            playerPos.PossesOject(player, this);

           
        }
    }
}
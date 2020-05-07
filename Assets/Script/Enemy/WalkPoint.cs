using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPoint : MonoBehaviour
{
    public int RoomId=0;
   
    void Start()
    {
        if(RoomId==0)
        {
            Debug.Log("Room with id 0!");
        }
    }
    public Transform GetPointTransform()
    {
        return transform;
    }

}

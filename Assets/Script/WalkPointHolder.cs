using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPointHolder : MonoBehaviour
{
    public static WalkPointHolder instance;
     public WalkPoint[] WalkPointers;
    void Awake()
    {
        instance = this;
        WalkPointers = FindObjectsOfType<WalkPoint>();
    }
    
    public Transform GetRandomPoint()
    {
        int rnd = Random.Range(0, WalkPointers.Length);
        return WalkPointers[rnd].GetPointTransform();
    }
    public Transform GetRandomPointFromRoom(int idRoom)
    {
        List<WalkPoint> FilterWalkPointers = new List<WalkPoint>();
        for (int i = 0; i < WalkPointers.Length; i++)
        {
            if(WalkPointers[i].RoomId== idRoom)
            {
                FilterWalkPointers.Add(WalkPointers[i]);
            }
        }
        int rnd = Random.Range(0, FilterWalkPointers.Count);
        return FilterWalkPointers[rnd].GetPointTransform();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPointHolder : MonoBehaviour
{
    public static WalkPointHolder instance;
    public Transform[] WalkPointers;
    void Awake()
    {
        instance = this;
    }
    public Transform[] GetAllWalkPoints()
    {
        return WalkPointers;
    }
    public Transform GetRandomPoint()
    {
        int rnd = Random.Range(0, WalkPointers.Length);
        return WalkPointers[rnd];
    }
}

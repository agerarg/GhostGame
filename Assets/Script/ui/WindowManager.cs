using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance;

    public GameObject possessionOptions;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        possessionOptions.SetActive(false);
    }

   public void SetPossessionOptions(bool set)
    {
        possessionOptions.SetActive(set);
    }
}

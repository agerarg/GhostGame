using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthFromEnemyes : MonoBehaviour
{
    public Transform target;
    public Vector3 OffSet;
    private Slider bar;
    void Start()
    {
        bar = GetComponent<Slider>();
    }

    public void UpdateStress(int s)
    {
        bar = GetComponent<Slider>();
        bar.value = s;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position + OffSet);
    }
}

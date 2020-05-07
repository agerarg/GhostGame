using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDiePool : MonoBehaviour
{
    int destroyerCount = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            destroyerCount++;
            if(destroyerCount>=5)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}

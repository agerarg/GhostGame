using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public float timeToWalkToPoint = 10f;
    private NavMeshAgent agent;
    private float timeStep=0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(timeStep>= timeToWalkToPoint)
        {
          Transform target =  WalkPointHolder.instance.GetRandomPoint();
          agent.destination = target.position;
            timeStep = 0;
        }
        timeStep += Time.deltaTime;
    }
}

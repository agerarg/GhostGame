using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour, IRoomSet
{
    public float timeToWalkToPoint = 10f;
    public int room = 0;
    private NavMeshAgent agent;
    private float timeStep = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void GetScared()
    {
        Destroy(gameObject);
    }
    public void AtractToRoom(int toRoom)
    {
        Transform target = WalkPointHolder.instance.GetRandomPointFromRoom(toRoom);
        agent.destination = target.position;
        timeStep = 0;
    }
    public void setRoom(int num)
    {
        room = num;
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

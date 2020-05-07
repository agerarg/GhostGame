using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour, IRoomSet
{
    public AudioClip basicScare;
    public AudioClip highScare;
    public Animator animator;
    public float timeToWalkToPoint = 10f;
    public int room = 0;
    public HealthFromEnemyes Health;
    private NavMeshAgent agent;
    private float timeStep = 100;
    private int stress = 0;
    private float stressStep;
    private bool isScared = false;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        Health.UpdateStress(stress);
    }
    public void GetScared()
    {
            if (stress >= 2)
            {
                audioSource.clip = highScare;
                audioSource.Play();
                Destroy(Health.gameObject);
                isScared = true;
                agent.destination = WalkPointHolder.instance.GTFO().position;
                animator.SetBool("RUN", true);
            }
            else
            {
                audioSource.clip = basicScare;
                audioSource.Play();
                stress++;
                Health.UpdateStress(stress);
                
            }
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
        if (!isScared)
        {
            if (timeStep >= timeToWalkToPoint)
            {
                Transform target = WalkPointHolder.instance.GetRandomPoint();
                agent.destination = target.position;
                timeStep = 0;
                timeToWalkToPoint = Random.Range(5f, 20f);
               
            }
            timeStep += Time.deltaTime;

            /*if (stressStep >= 3)
            {
                if (CheckIfImAlone())
                {
                    stress++;
                    Health.UpdateStress(stress);
                }
                stressStep = 0;
            }
            stressStep += Time.deltaTime;
            */
            float velocity = agent.velocity.magnitude;
            if (velocity > 0.5f)
            {
                animator.SetBool("RUN", true);
            }
            else
            {
                animator.SetBool("RUN",false);
          }

        }
    }
    private bool CheckIfImAlone()
    {
        EnemyMovement[] Enemys = FindObjectsOfType<EnemyMovement>();
        int pplOnRoom = 0;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i].room == room)
            {
                pplOnRoom++;
            }

        }
        if (pplOnRoom == 1)
        {
            return true;
        }
        return false;
    }
}

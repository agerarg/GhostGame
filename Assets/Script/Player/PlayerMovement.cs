using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public bool mouseOverSomeThing;
    private NavMeshAgent agent;
    private bool allowToMove = true;
    private float playerHeigth = 5.18f;
    private PlayerPoses playerPos;
    private float possessionCooldown = 0f;
    void Start()
    {
        playerPos = (PlayerPoses)FindObjectOfType(typeof(PlayerPoses));
        agent = GetComponent<NavMeshAgent>();
        allowToMove = true;
    }
    public void Stop()
    {
        agent.isStopped = true;
    }
    public Transform GetTransform()
    {
        return transform;
    }
    public void SetPositionTo(Vector3 newPos)
    {

        //newPos.y = transform.position.y;
        //agent.Warp(newPos);
    }
    public void PossesionCooldown()
    {
        possessionCooldown = 1f;
    }
    public void AllowMoving(bool set)
    {
        allowToMove = set;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && possessionCooldown <= 0 && !mouseOverSomeThing)
        {

            if (!allowToMove)
            {
                    playerPos.StopPosses();
                    allowToMove = true;
                    agent.isStopped = false;
            }
            else
            {
                RaycastHit hit;
                Vector3 mousePos = Input.mousePosition;
                mousePos = new Vector3(mousePos.x, playerHeigth, mousePos.z);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }

        if (possessionCooldown > 0)
        {
            possessionCooldown -= Time.deltaTime;
        }
    }
}

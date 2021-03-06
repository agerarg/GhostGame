﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int setRoom=0;
    public int[] adjacentRooms;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        IRoomSet roomset = other.GetComponent< IRoomSet>();
        if(roomset!=null)
        {
            roomset.setRoom(setRoom);
        }
    }
    public void AtractIfSomeoneThere()
    {
        EnemyMovement[] Enemys = FindObjectsOfType<EnemyMovement>();

        for (int i = 0; i < Enemys.Length; i++)
        {
            for (int j = 0; j < adjacentRooms.Length; j++)
            {
                if (Enemys[i].room == adjacentRooms[j])
                {
                    Enemys[i].AtractToRoom(setRoom);
                }
            }
        }
    }

    public void GtfoFromThere()
    {
        EnemyMovement[] Enemys = FindObjectsOfType<EnemyMovement>();

        int rnd = 0;
        int roomToRun = 0;

        for (int i = 0; i < Enemys.Length; i++)
        {
             if (Enemys[i].room == setRoom)
                {
                    rnd = Random.Range(0, adjacentRooms.Length);
                    roomToRun = adjacentRooms[rnd];
                    Enemys[i].AtractToRoom(roomToRun);
                }
        }
    }

    public void Scare()
    {
        EnemyMovement[] Enemys = FindObjectsOfType<EnemyMovement>();
        EnemyMovement AloneInRoom = null;
        int pplOnRoom = 0;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i].room == setRoom)
            {
                pplOnRoom++;
                AloneInRoom = Enemys[i];
            }
        }
        if(pplOnRoom==1)
        {
            GtfoFromThere();
            AloneInRoom.GetScared();
        }

        

    }

}

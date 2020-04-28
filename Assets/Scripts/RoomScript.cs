using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject vcam;
    private bool wasHere = false;
    public GameObject doorsh;
    private int deadEnemies = 0;
    private Animator animatorDoorh;
    public GameObject doorsv;
    private Animator animatorDoorv;


    public void Start()
    {
        GetComponent<EnemySpawnerScript>().enabled = false;
        animatorDoorh = doorsh.GetComponent<Animator>();
        animatorDoorv = doorsv.GetComponent<Animator>();
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger 
        && !wasHere)
        {
            vcam.SetActive(true);
            GetComponent<EnemySpawnerScript>().enabled = true;
            wasHere = true;
        }
        else if (other.CompareTag("Player") && !other.isTrigger)
        {
            vcam.SetActive(true);
            GetComponent<EnemySpawnerScript>().enabled = false;
        }
    }
    

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            vcam.SetActive(false);
        }

        if (other.CompareTag("Enemy"))
        {
            deadEnemies++;
            if (deadEnemies >= GetComponent<EnemySpawnerScript>().spawnNumber)
            {
                OpenDoors();
            }
        }
    }

    public void OpenDoors()
    {
        animatorDoorh.SetTrigger("open");
        doorsh.GetComponent<BoxCollider2D>().enabled = false;
        animatorDoorv.SetTrigger("open");
        doorsv.GetComponent<BoxCollider2D>().enabled = false;
    }
}

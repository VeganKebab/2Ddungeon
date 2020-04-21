using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject vcam;
    private bool wasHere = false;
    
    

    public void Start()
    {
        GetComponent<EnemySpawnerScript>().enabled = false;
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
    }
}

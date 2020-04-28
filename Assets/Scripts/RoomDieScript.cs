using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDieScript : MonoBehaviour
{
    public GameObject vcam;
    public GameObject blackHole;
    public GameObject Character;
    private Animator charAnimator;
    public GameObject restart;
    public GameObject newPosition;
    public float holeDistance = 2f;
    
    // Start is called before the first frame update

    private void Start()
    {
        charAnimator = Character.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(Character.transform.position, blackHole.transform.position) < holeDistance)
        {
            charAnimator.SetTrigger("blackhole");
            Character.GetComponent<PlayerMovement>().enabled = false;
            if (charAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                Character.SetActive(false);
                restart.SetActive(true);
            }
            
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            vcam.SetActive(true);
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
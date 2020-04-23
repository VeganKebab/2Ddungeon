using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float maxHealth;
    float currentHealth;
    public int scoreToGive;
    public Animator animator;
    public GameObject blood;
    public GameObject deathParticle;
    public GameObject Character;
    
    void Start()
    {
        currentHealth = maxHealth;
        Character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.activeSelf)
        {
            if (Vector2.Distance(transform.position, Character.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Character.transform.position, speed * Time.deltaTime);
            }
            else if(Vector2.Distance(transform.position, Character.transform.position) < stoppingDistance){
                transform.position = this.transform.position;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        Instantiate(blood, transform.position, Quaternion.identity);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        SoundManagerScript.PlaySound("enemy1death");
        Destroy(gameObject);
        ScoreScript.score += scoreToGive;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float destroyDistance;
    public float maxHealth;
    float currentHealth;
    public int scoreToGive;
    public Animator animator;
    public GameObject blood;
    public GameObject DeathParticle;
    
    public Transform player;
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance){
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) == destroyDistance){
            Destroy(gameObject);
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
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScoreScript.score += scoreToGive;
    }
}

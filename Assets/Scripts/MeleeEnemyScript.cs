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
    public float attackRange = 5f;
    public int attackPower = 5;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public GameObject attackPoint;
    
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
            if (Vector2.Distance(transform.position, Character.transform.position) < attackRange && Time.time >= nextAttackTime)
            {
                CharHealthScript.TakeDamage(attackPower);
                nextAttackTime = Time.time + 1f / attackRate;
            }
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
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}

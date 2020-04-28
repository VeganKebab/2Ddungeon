using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharHealthScript : MonoBehaviour
{
    public HealthbarScript Healthbar;
    public int maxHealth = 100;
    public static int currentHealth;
    public GameObject restart;
    public GameObject deathParticle;
    public GameObject character;
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Instantiate(deathParticle, character.transform.position, Quaternion.identity);
            Die();
        }
    }

    public static void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("chardamage");
        currentHealth -= damage;
        
    }

    void Die()
    {
        restart.SetActive(true);
        gameObject.SetActive(false);
    }

}

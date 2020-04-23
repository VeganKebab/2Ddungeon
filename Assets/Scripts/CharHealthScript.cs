using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharHealthScript : MonoBehaviour
{
    public HealthbarScript Healthbar;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject restart;
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
            Die();
        }
    }

    void TakeDamage(int damage)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHealthScript : MonoBehaviour
{
    public HealthbarScript Healthbar;
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.SetHealth(currentHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    
}

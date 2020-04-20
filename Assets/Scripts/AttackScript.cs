using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class AttackScript : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackFunction();
        }
    }

    void AttackFunction()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit:" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

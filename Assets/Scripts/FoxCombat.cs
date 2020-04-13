﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        // attack animation
        // detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // damage them 
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag("Stump"))
            {
                enemy.gameObject.GetComponent<Stump>().Die();
            }
            enemy.gameObject.GetComponent<EnemyMovement>().Die();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    Animator anim;
    public float AttackTime = 0.5f;
    // Update is called once per frame

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                StartCoroutine(AttackAnim());
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
            if (enemy.gameObject.CompareTag("Wisp"))
            {
                enemy.gameObject.GetComponent<Wisp>().Die();
            }
            if (enemy.gameObject.CompareTag("Rock"))
            {
                enemy.gameObject.GetComponent<RockMovement>().Die();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackAnim()
    {
        anim.SetTrigger("Attack");
        GetComponent<FoxController>().isAttack = true;
        yield return new WaitForSeconds(AttackTime);
        GetComponent<FoxController>().isAttack = false;
    }
}

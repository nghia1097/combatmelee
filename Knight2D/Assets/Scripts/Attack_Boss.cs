using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Boss : MonoBehaviour
{
    public Transform attackPoint;
    public float rangeAttack = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamge = 40;
    public int timeAttack = 3;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
    }
 
    public void Attack()
    {
        ani.SetTrigger("Attack");
        // Detec enemy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, rangeAttack, enemyLayers);
        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Player>().TakeDamge_Player(attackDamge);
            Debug.Log(enemy.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, rangeAttack);
    }
}

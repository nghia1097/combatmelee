using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Player : MonoBehaviour
{
    public Animator ani;
    public Transform attackPoint;
    public float rangeAttack = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamge = 40;
    public float rateAttack = 2f;
    float nextTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            // animaton
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("attack");
                nextTime = Time.time;
                Attack();
            }
        }
        
    }
    void Attack()
    {
        // play animation attack
        ani.SetTrigger("Attack");
        // Detec enemy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, rangeAttack, enemyLayers);
        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamge(attackDamge);
            Debug.Log("hit "+enemy.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, rangeAttack);
    }

}

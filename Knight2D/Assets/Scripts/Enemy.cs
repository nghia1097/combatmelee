using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator ani;
    public int maxHealth = 100;
    int currentHealth;
    public GameObject gameObjectBoss;
    // assgin healbar_boss
    public healthBar_Boss HealthBar_Boss;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar_Boss.Setmaxhealth(maxHealth);
        currentHealth = maxHealth;
    }
    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        ani.SetTrigger("Hurt");
        if (currentHealth <= 0)
            Die();
        // giam thanh mau
        HealthBar_Boss.Sethealth(currentHealth);
    }
    void Die()
    {
        Debug.Log("enemy died");
        // Die animation
        ani.SetBool("isDead", true);
        // Disable enemy
        Enable();
    }
    void Enable()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        // yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObjectBoss.SetActive(false);
    }
    // Update is called once per frame

}

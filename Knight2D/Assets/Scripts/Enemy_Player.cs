using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Player : MonoBehaviour
{
    public GameObject boss;
    Animator ani_boss;
    public int maxHealth = 100;
    int currentHealth;
    public healthBar_Player HealthBar_Player;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar_Player.Setmaxhealth(maxHealth);
        ani_boss = boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge_Player(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        // Debug.Log(currentHealth);
        // healBar_player
        HealthBar_Player.Sethealth(currentHealth);
        if (currentHealth <= 0)
        {
            ani_boss.SetTrigger("Win");
            Destroy(gameObject);
            Debug.Log(name + "died");
        }
            
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    public GameObject dieEffect;
    public GameObject hurtEnemyEffect;

    public event Action<int> OnDeath; // Evento acionado quando o tentáculo morre
    public bool isDead { get; private set; }

    public void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        Instantiate(hurtEnemyEffect, transform.position, transform.rotation);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("HurtEnemy"); 
      
        if(currentHealth < 0)
        {
            Die();
        }
    }
 
    public virtual void Die()
    {
        if (!isDead)
        {
        isDead = true;
        OnDeath?.Invoke(1); // Aciona o evento de morte
        Destroy(gameObject, 0.1f); 
        Instantiate(dieEffect, transform.position, transform.rotation);
        }
    }
}

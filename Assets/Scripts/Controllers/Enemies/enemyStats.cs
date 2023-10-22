using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    //public Stat damage;
    public int maxHealth = 5;
    public int currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private enemyCogu coguExplosion;
    public GameObject explosionEffect;

    public void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        coguExplosion = GetComponent<enemyCogu>();
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        //Debug.Log(transform.name + "takes" + damage + "damage");
        
        if(currentHealth < 0)
        {
            Die();
        }
    }
 
    public virtual void Die()
    {
        anim.SetTrigger("die");
        //Debug.Log(transform.name + "died.");
        Destroy(gameObject); 
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //coguExplosion.DieExplosion();
    }
}

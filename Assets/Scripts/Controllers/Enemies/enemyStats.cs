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
    public GameObject dieEffect;
    public GameObject hurtEnemyEffect;

    public void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        coguExplosion = GetComponent<enemyCogu>();
    }

    public void TakeDamage(int damage)
    {
        //anim.SetTrigger("hurt");
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
        //anim.SetTrigger("die");
        Destroy(gameObject); 
        Instantiate(dieEffect, transform.position, transform.rotation);
        //coguExplosion.DieExplosion();
    }
}

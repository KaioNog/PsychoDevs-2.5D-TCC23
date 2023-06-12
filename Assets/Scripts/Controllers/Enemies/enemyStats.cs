using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    private float startingHealth = 5;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if(!dead)
            {
                Debug.Log("Enemy die");
                dead = true;
                anim.SetTrigger("die");
                //GetComponent<zKaiController>().enabled = false;
                Destroy(gameObject, 5);            
            }
        }
    }
}

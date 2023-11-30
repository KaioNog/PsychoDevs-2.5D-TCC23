using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusMiniBoss : Interactable
{
    private Animator Anim;
    private enemyStats stats;
    [SerializeField] private float damage;

    private float attackInterval = 2f; // Intervalo de tempo entre os ataques
    private float attackTimer;

    //[SerializeField] private float EspecialDamage;
   // private float EspecialAttackInterval = 6f; // Intervalo de tempo entre os ataques
    //private float EspecialAttackTimer;

    private void Awake()
    {
        stats = GetComponent<enemyStats>();
        Anim = this.GetComponent<Animator>();
    }

    public void Update()
    {
        if ((Input.GetKeyUp(KeyCode.K)) && PlayerInRange())
        {
            stats.TakeDamage(1); //dano que o player dá no inimigo
        }

        //enemy atk
        if (PlayerInRange())
        {
            //if collision player
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;
                AttackPlayer();
                Debug.Log("atk");
            }  
            else
            {
                Anim.SetBool("atk", false);
            }         
        }
        /*enemy especial atk
        if (PlayerInRange())
        {
            //if collision  player{}
            EspecialAttackTimer += Time.deltaTime;

            if (EspecialAttackTimer >= EspecialAttackInterval)
            {
                EspecialAttackTimer = 0f;
                AttackPlayer();
                Debug.Log("atk especial");
            }  
            /*else
            {
                Anim.SetBool("atk2", false);
            }         
        }*/
    }

    private void AttackPlayer()
    {
        if (PlayerInRange())
        {
            Anim.SetBool("atk", true);
            Health playerHealth = FindObjectOfType<Health>();
            playerHealth.TakeDamage(damage);
        }
    }

    /*private void AttackEspecialPlayer()
    {
        if (PlayerInRange())
        {
            Anim.SetBool("atk2", true);
            Health playerHealth = FindObjectOfType<Health>();
            playerHealth.TakeDamage(EspecialDamage);
        }
    }*/

    public override void Interact()
    {
        base.Interact();
    }

    private bool PlayerInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(interactionTransform.position, enemyRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}



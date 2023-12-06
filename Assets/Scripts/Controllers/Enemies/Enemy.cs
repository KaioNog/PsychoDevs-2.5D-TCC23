using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{

    private Animator Anim;
    private enemyStats stats;
    [SerializeField] private float damage;

    private float attackInterval = 1f; // Intervalo de tempo entre os ataques
    private float attackTimer;

    private void Awake()
    {
        stats = GetComponent<enemyStats>();
    }

    private void Start()
    {
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
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;
                AttackPlayer();
            }     
        }
    }

    private void AttackPlayer()
    {
        if (PlayerInRange())
        {
            Anim.SetBool("atk", true);
            Health playerHealth = FindObjectOfType<Health>();
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Anim.SetBool("atk", false);
        }  
    }

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

        /*if(collision.gameObject.CompareTag("Shoot"))
        {
            stats.TakeDamage(10);
            Debug.Log("Dano Shoot");
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Shoot"))
        {
            stats.TakeDamage(5);
            Debug.Log("Dano Shoot");
        }
    }
}

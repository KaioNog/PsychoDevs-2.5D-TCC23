using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlanta : Interactable
{
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject planta;

    public int maxHealth = 5;
    public int currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private float attackInterval = 1.5f;
    private float attackTimer;
    private float attackSpeed = 5f;
    private float attackLifetime = 5f;
    public float playerAttackRadius = 5f;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        //dano que o player dá no inimigo
        if ((Input.GetKeyUp(KeyCode.K)) && PlayerInRangeATK(playerAttackRadius))
        {
            TakeDamage(2); 
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
            /*else
            {
                Anim.SetBool("atk", false);           

            }*/              
        }
    }


    private void AttackPlayer()
    {
        if (PlayerInRange())
        {
            GameObject attackInstance = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            enemyPlantaAtk attackComponent = attackInstance.GetComponent<enemyPlantaAtk>();

            attackComponent.SetAttackDirection(player.transform);

            Destroy(attackInstance, attackLifetime);
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

    private bool PlayerInRangeATK(float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(interactionTransform.position, radius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }   

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage");
        
        if(currentHealth < 0)
        {
            Die();
        }
    }
 
    public virtual void Die()
    {
        //anim.SetTrigger("die");
        Debug.Log(transform.name + "died.");
        Destroy(gameObject); 
        Destroy(planta); 
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, enemyRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, playerAttackRadius);
    }
}

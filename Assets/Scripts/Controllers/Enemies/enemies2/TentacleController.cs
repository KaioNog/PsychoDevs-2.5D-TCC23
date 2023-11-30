using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : Interactable
{
    private enemyStats stats;
    public float attackRange = 2f;
    public int damage = 1;
    public float attackCooldown = 2f;
    private bool isAttacking = false;
    public bool canDamage = false;
    public GameObject tentacleColliderObject;

    private void Awake()
    {
        stats = GetComponent<enemyStats>();
    }

    private void Update()
    {
        if (PlayerInRange() && !isAttacking)
        {
            StartCoroutine(AttackCoroutine());
            Debug.Log("Chamar ataque");
        }
        else
        {
            isAttacking = false;
        }

        /*if(CheckCollisionWithPlayer())
        {
            //canDamage = true;
        }*/
    }

    public override void Interact()
    {
        base.Interact();
    }  

    private bool PlayerInRange() //player no raio, ataque iniciar
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
    
    IEnumerator AttackCoroutine() //ataca
    {
        isAttacking = true;
        GetComponent<Animator>().SetTrigger("atk");
        yield return new WaitForSeconds(0.5f);
        
        if (canDamage) //troquei pelo script direto no colider que acompanha a animação
        {
            // Causa dano ao jogador
            Health playerHealth = FindObjectOfType<Health>();
            playerHealth.TakeDamage(damage);
            Debug.Log("Bateu no player");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    /*private bool CheckCollisionWithPlayer() //colisao com player
    {
        CapsuleCollider tentacleCollider = tentacleColliderObject.GetComponent<CapsuleCollider>();
        Collider[] hitColliders = Physics.OverlapCapsule(tentacleCollider.center, tentacleCollider.bounds.center, tentacleCollider.radius);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }*/
}
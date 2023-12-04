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
        }
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

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
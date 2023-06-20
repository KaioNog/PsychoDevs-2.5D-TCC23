using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    private enemyStats stats;

    private void Awake()
    {
        stats = GetComponent<enemyStats>();
    }

    public void Update()
    {
        if ((Input.GetKeyUp(KeyCode.K)) && PlayerInRange())
        {
            stats.TakeDamage(1);
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
}

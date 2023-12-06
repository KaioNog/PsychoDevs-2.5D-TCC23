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
    public SkinnedMeshRenderer tentacleRenderer; // Use SkinnedMeshRenderer para personagens com animações complexas
    public Material defaultTentacleMaterial;
    public Material redTentacleMaterial;
    private float durationHurt = 0.2f;

    private void Awake()
    {
        stats = GetComponent<enemyStats>();
        tentacleRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
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

    public void ChangeTentacleToRed()
    {
        tentacleRenderer.material = redTentacleMaterial;
    }

    public void ResetTentacleColor()
    {
        tentacleRenderer.material = defaultTentacleMaterial;
    }

    public    IEnumerator changeColorTentacles()
    {
        float initialTime = Time.time;
 
            ChangeTentacleToRed();
            Debug.Log("red octopus");

            while (Time.time < initialTime + durationHurt)
            {
                yield return null;
            }

            ResetTentacleColor();
            Debug.Log("reset color octopus");
    
    }
}
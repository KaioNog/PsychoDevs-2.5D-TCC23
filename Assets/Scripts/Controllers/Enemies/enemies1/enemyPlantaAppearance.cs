using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlantaAppearance : MonoBehaviour
{
    public Transform aboveGroundPosition; // A posição acima da terra onde o mini boss aparecerá.
    public float playerDetectionRadius = 5f; // Raio de detecção do jogador para ativar a aparição.

    private Transform miniBossTransform;
    private Transform initialPosition;
    private bool isAboveGround;

    private Animator anim;

    private void Start()
    {
        miniBossTransform = transform;
        initialPosition = miniBossTransform;
        isAboveGround = false;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAboveGround && PlayerInRange())
        {
            // Ative a aparição acima da terra.
            miniBossTransform.position = aboveGroundPosition.position;
            isAboveGround = true;

                anim.SetBool("Appearance", true);           
        }
    }

    private bool PlayerInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(miniBossTransform.position, playerDetectionRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(miniBossTransform.position, playerDetectionRadius);
    }
}

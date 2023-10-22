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
    private CameraZoom cameraZoom; // Adicione esta referência
    
    private void Start()
    {
        miniBossTransform = transform;
        initialPosition = miniBossTransform;
        isAboveGround = false;
        anim = GetComponent<Animator>();
        cameraZoom = Camera.main.GetComponent<CameraZoom>(); // Obtém a referência do componente CameraZoom
    }

    private void Update()
    {
        if (!isAboveGround && PlayerInRange())
        {
            // Ative a aparição acima da terra.
            miniBossTransform.position = aboveGroundPosition.position;
            isAboveGround = true;
            anim.SetBool("Appearance", true);  
            cameraZoom.ActivateZoom(); 
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

    /*public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(miniBossTransform.position, playerDetectionRadius);
    }*/
}

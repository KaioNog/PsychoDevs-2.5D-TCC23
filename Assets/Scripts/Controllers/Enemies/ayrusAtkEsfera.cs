using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayrusAtkEsfera : MonoBehaviour
{
    private float damage = 2;
    private Transform playerTransform;
    private Vector3 attackDirection;
    private float attackSpeed = 13f; // Velocidade de movimento da esfera de ataque 
    private bool canRicochet; // Variável de controle para permitir o ricochete

    public void SetAttackDirection(Transform target)
    {
        playerTransform = target;
        attackDirection = (playerTransform.position - transform.position).normalized;
    }

    private void Update()
    {
        // Movimentar a esfera de ataque na direção correta a cada quadro
        transform.position += attackDirection * attackSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.K))
        {
            canRicochet = true;
        }
        else
        {
            canRicochet = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && canRicochet)
        {          
            attackDirection = -attackDirection;
            //se colidir com o inimigo (tag "AyrusAtk"), o inimigo leva dano
        }            
        
        if (collision.CompareTag("Player") && !canRicochet)
        {
                collision.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AyrusAtk"))
        {
            Debug.Log("pegou no ayrus");
            AyrusAtk ayrusAtk = collision.gameObject.GetComponent<AyrusAtk>();
            ayrusAtk.TakeDamage(5);
            // Destruir a esfera após atingir o inimigo
            Destroy(gameObject);
        }
    }
}
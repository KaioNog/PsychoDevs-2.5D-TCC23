using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlantaAtk1 : MonoBehaviour
{
    private float damage = 2;

    private Transform playerTransform;
    private Vector3 attackDirection;
    private float attackSpeed = 10f; // Velocidade de movimento da esfera de ataque

    public void SetAttackDirection(Transform target)
    {
        playerTransform = target;
        attackDirection = (playerTransform.position - transform.position).normalized;
    }

    private void Update()
    {
        // Movimentar a esfera de ataque na direção correta a cada quadro
        transform.position += attackDirection * attackSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControllerDamage : MonoBehaviour
{
   [SerializeField] private float damage;
    private enemyStats stats;
    public float enemyRadiusDamage = 3f;

    private void Awake()
    {
        stats = GetComponentInParent<enemyStats>(); // script de vida do inimigo
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            // Verifica se o jogador está dentro da distância de ataque
            float distance = Vector3.Distance(transform.position, FindObjectOfType<zKaiController>().transform.position);
            if (distance < enemyRadiusDamage)
            {
                // Causa dano ao tentáculo
                stats.TakeDamage(1);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControllerDamage : MonoBehaviour
{
   [SerializeField] private float damage;
    private enemyStats stats;
    public float enemyRadiusDamage = 3f;
    public bool collisionDetected = false;
    public bool canDamage = false;

    private void Awake()
    {
        stats = GetComponentInParent<enemyStats>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Dano no player");
        }
    }
}

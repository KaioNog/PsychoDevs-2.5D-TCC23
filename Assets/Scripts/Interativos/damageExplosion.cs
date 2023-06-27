using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageExplosion : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

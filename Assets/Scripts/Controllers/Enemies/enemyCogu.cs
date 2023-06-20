using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCogu : MonoBehaviour
{
    public GameObject explosionEffect; 
    [SerializeField] private float damage;

    public void DieExplosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

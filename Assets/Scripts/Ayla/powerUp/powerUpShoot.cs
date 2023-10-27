using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpShoot : MonoBehaviour
{
    public GameObject pickupEffect;
    public ProjectileSpawn projectileSpawn; // Referência ao script ProjectileSpawn

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        projectileSpawn.canShoot = true;

        Debug.Log("Tiro ativado");
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("ColetaPowerUp"); 
    }
}

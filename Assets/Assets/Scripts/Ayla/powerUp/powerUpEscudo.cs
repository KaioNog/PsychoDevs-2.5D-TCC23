using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpEscudo : MonoBehaviour
{
    public GameObject pickupEffect;

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

        zKaiController controller = player.GetComponent<zKaiController>();
        controller.canShield = true;

        Debug.Log("Escudo ativado");
        Destroy(gameObject);
    }
}

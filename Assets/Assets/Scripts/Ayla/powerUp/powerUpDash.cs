using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpDash : MonoBehaviour
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
        controller.canDash = true;

        Debug.Log("Dash ativado");

        Destroy(gameObject);
    }
}

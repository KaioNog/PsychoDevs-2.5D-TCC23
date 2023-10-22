using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScoreController : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerData.playerDataInstance.AddScore(m:10);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("ColetaMana"); 
        }
    }
}

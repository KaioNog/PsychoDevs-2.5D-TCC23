using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCogu : MonoBehaviour
{
    public GameObject explosionEffect; 

    public void DieExplosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}

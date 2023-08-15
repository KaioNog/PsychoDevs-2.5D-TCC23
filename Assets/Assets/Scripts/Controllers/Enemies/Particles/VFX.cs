using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] GameObject fireVFX;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(fireVFX, transform.position, transform.rotation);
            Destroy(explosion, 0.75f);        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField]private float healthValue;
    private float velocityRotation = 110;
    public GameObject healthEffect;
   
    void Update()
    {
        transform.Rotate(0, velocityRotation * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            Instantiate(healthEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Health"); 
        }
    }
}

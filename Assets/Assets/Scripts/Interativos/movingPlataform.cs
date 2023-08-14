using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movingPlataform : MonoBehaviour
{
    private float velocityPlataform = 1f;

    void FixedUpdate()
    {
        this.transform.position += new Vector3(0, 0, velocityPlataform * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            velocityPlataform *= -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(this.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}

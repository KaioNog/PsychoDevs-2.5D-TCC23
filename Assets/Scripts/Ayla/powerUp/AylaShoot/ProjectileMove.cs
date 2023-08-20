using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    void Start()
    {
        if(muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate (muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
    }

    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }

    public void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Destroy(col.gameObject); // Destruir o objeto com a tag "Obstacle"
        }
        else
        {
            speed = 0;

            ContactPoint contact = col.contacts[0];
            Vector3 pos = contact.point;

            if (hitPrefab != null)
            {
                var hitVFX = Instantiate(hitPrefab, pos, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

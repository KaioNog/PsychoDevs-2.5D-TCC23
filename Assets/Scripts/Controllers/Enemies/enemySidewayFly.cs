using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySidewayFly : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.z - movementDistance;
        rightEdge = transform.position.z + movementDistance;
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(transform.position.z > leftEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            else
                movingLeft = false;
        }    
        else
            if(transform.position.z < rightEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            else
                movingLeft = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

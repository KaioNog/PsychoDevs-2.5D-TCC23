using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlataform : MonoBehaviour
{
    public float fallTime = 1f;
    private float destroyTime = 1.5f;
    private float reappearTime = 2f;
    private Rigidbody rb;
    private Vector3 lastPosition;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        lastPosition = this.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallTime);
        rb.useGravity = enabled;
        yield return new WaitForSeconds(destroyTime);
        this.gameObject.SetActive(false);
        Invoke("Reappear", reappearTime);        
    }

    private void Reappear()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = lastPosition;
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
    }
}

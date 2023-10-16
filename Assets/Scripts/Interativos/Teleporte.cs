using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta o eixo Z do jogador em 10
            Vector3 newPosition = other.transform.position;
            newPosition.z += 10f;
            other.transform.position = newPosition;
        }
    }
}

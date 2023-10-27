using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move o jogador 20 unidades no eixo Z
            other.transform.Translate(Vector3.forward * 25f);
        }
    }
}
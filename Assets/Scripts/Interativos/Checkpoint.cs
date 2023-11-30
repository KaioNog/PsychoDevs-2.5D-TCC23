using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Variável para armazenar a posição do checkpoint
    private Vector3 checkpointPosition;

    private void Start()
    {
        // Inicializa a posição do checkpoint no início do jogo
        checkpointPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag("Player"))
        {
            // Atualiza a posição do checkpoint para a posição atual do jogador
            checkpointPosition = other.transform.position;
        }
    }

    // Método para obter a posição do checkpoint
    public Vector3 GetCheckpointPosition()
    {
        return checkpointPosition;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float rotationSpeed = 180f;

    private Vector3 offset;

    private void Start()
    {
        // Calcule o deslocamento inicial entre o corvo e o jogador
        offset = transform.position - player.position;
    }

    private void Update()
    {
        // Obtenha a posição alvo do corvo (a posição atual do jogador mais o deslocamento)
        Vector3 targetPosition = player.position + offset;

        // Gradualmente mova o corvo em direção à posição alvo
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        /*      
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingFishController : MonoBehaviour
{
    //movement
    public Transform[] points;
    int current;
    public float speed;

    void Start()
    {
        current = 0;
    }

    void Update()
    {
        // Verificar a direção do movimento antes de efetuar o movimento
        Vector3 direction = points[current].position - transform.position;

        if (direction != Vector3.zero)
        {
            // Rotação em direção ao próximo ponto
            transform.rotation = Quaternion.LookRotation(direction.normalized);
        }

        // Movimentar o inimigo
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
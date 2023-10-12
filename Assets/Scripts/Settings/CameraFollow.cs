using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    private Vector3 offset;
    private Vector3 initialPosition; // Posição inicial antes do shake
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private Vector3 shakeStartPosition; // Posição da câmera no início do shake

    private float initialFOV;

    void Start()
    {
        offset = transform.position - target.position;
        initialPosition = transform.position; // Salva a posição inicial
        initialFOV = Camera.main.fieldOfView;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        // Se a câmera está tremendo
        if (shakeDuration > 0)
        {
            // Calcula a posição de shake baseada na posição inicial do shake
            Vector3 shakePos = shakeStartPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.position = shakePos;

            // Reduz a duração do shake ao longo do tempo
            shakeDuration -= Time.deltaTime * 1.5f;
        }
        else
        {
            // Interpola suavemente de volta para a posição de destino se não estiver tremendo
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }

    public void TriggerShake()
    {
        // Salva a posição atual da câmera para o shake
        shakeStartPosition = transform.position;

        // Inicia o efeito de shake
        shakeDuration = 0.3f;
    }

    public void ResetCameraPosition()
    {
        // Reseta a posição da câmera para a posição inicial
        transform.position = initialPosition;
    }
}
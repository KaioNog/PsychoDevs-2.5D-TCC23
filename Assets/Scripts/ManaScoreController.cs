using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScoreController : MonoBehaviour
{
    private float velocityRotation = 80;

    void Update()
    {
        transform.Rotate(0, 0, velocityRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerData.playerDataInstance.AddScore(m:1);
            Destroy(this.gameObject);
        }
    }
}

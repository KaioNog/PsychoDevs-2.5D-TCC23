using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScoreController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerData.playerDataInstance.AddScore(m:10);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControllerHealth : MonoBehaviour
{
    private enemyStats stats;
    public bool canDamage = false;
    public TentacleController tentacleController;

    private void Awake()
    {
        stats = GetComponentInParent<enemyStats>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K) && canDamage)
        {

            Debug.Log("Dano no octoppus");
            stats.TakeDamage(1);
            if (tentacleController != null)
            {
                tentacleController.StartCoroutine(tentacleController.changeColorTentacles());
            }
            else
            {
                Debug.LogWarning("TentacleController não foi atribuído a TentacleControllerHealth.");
            }        
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            canDamage = true;
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDamage = false;
        }
    }
}

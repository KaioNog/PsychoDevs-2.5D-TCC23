using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float enemyRadius = 3f;
    public Transform interactionTransform;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, enemyRadius);
    }

    public virtual void Interact()
    {
        //overwritten
        Debug.Log("Interacting with" + transform.name);
    }
}

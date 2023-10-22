using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    //chamar outro script
    public LayerMask playerLayer;
    public float radious;
    private bool onRadious;
    private DialogueControl dc;
    private bool dialogueShown = false;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        InteractDialogue();
    }

    private void Update()
    {
        if (onRadious && !dialogueShown)
        {
            dc.Speech(profile, speechTxt, actorName);
            radious = 0;
            dialogueShown = true;
        }
    }

    public void InteractDialogue()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, radious, playerLayer);
        if(hitPlayer.Length > 0)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}

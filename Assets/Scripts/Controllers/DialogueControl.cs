using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    public float displayDuration;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());

        StartCoroutine(HideAfterDuration());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator HideAfterDuration()
    {
        yield return new WaitForSeconds(displayDuration);
        HideDialogue();
    }

    void HideDialogue()
    {
        // Reiniciar os elementos do diálogo para a próxima vez que for exibido
        speechText.text = "";
        dialogueObj.SetActive(false);
    }
}

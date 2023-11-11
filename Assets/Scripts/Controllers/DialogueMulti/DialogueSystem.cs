using UnityEngine;

public enum STATE {
    DISABLED,
    WAITING,
    TYPING
}

public class DialogueSystem : MonoBehaviour {

    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    void Awake() {

        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinishe;

    }

    void Start() {
        state = STATE.DISABLED;
    }

    void Update() {

        if(state == STATE.DISABLED) return;

        switch(state) {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }

    }

    public void Next() {

        Debug.Log($"Current Text: {currentText}, List Count: {dialogueData.talkScript.Count}");

        if(currentText == 0) {
            dialogueUI.Enable();
        }

        if (dialogueData != null && currentText < dialogueData.talkScript.Count)
        {
            dialogueUI.SetName(dialogueData.talkScript[currentText].name);
            dialogueUI.SetProfile(dialogueData.talkScript[currentText].imageProfile); // Configura o perfil
            typeText.fullText = dialogueData.talkScript[currentText++].text;
        }
    
        if(currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTyping();
        state = STATE.TYPING;            
    }

    void OnTypeFinishe() {
        state = STATE.WAITING;
    }

    void Waiting() {

        if(Input.GetKeyDown(KeyCode.Return)) {

            if(!finished) {
                Next();
            } else {
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentText = 0;
                finished = false;
            }

        }

    }

    void Typing() {

        if(Input.GetKeyDown(KeyCode.Return)) {
            typeText.Skip();
            state = STATE.WAITING;
        }

    }

}
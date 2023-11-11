using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour {

    Image background;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;
    Image profileImage;

    public float speed = 10f;
    bool open = false;

    void Awake() {
        background = transform.GetChild(0).GetComponent<Image>();
        nameText   = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText   = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        profileImage = transform.GetChild(3).GetComponent<Image>();
    }

    void Start() {
        Disable();
    }

    void Update() {
        if(open) {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 1, speed * Time.deltaTime);
        } else {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 0, speed * Time.deltaTime);
        }
    }

    public void SetName(string name) {
        nameText.text = name;
    }

    public void SetProfile(Sprite imageProfile) {
        profileImage.sprite = imageProfile;
    }

    public void Enable() {
        background.fillAmount = 0;
        open = true;
        profileImage.enabled = true; // ativa a imagem do perfil
    }

    public void Disable() {
        open = false;
        nameText.text = "";
        talkText.text = "";
        profileImage.sprite = null; // Limpa a imagem do perfil
        profileImage.enabled = false; // Desativa a imagem do perfil
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainOptions : MonoBehaviour
{
    public GameObject BackOptionsButton;

    private GameObject currentOptionsButton;

    void Start()
    {
        currentOptionsButton = BackOptionsButton;
        currentOptionsButton.GetComponent<Button>().Select();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            currentOptionsButton.GetComponent<Button>().onClick.Invoke();
        }
    }
}

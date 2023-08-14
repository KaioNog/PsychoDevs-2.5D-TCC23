using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeNextlvl : MonoBehaviour
{
    public GameObject changeNextLvlButton;
    private GameObject currentChangeNextLvlButton;

    void Start()
    {
        currentChangeNextLvlButton = changeNextLvlButton;
        currentChangeNextLvlButton.GetComponent<Button>().Select();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            currentChangeNextLvlButton.GetComponent<Button>().onClick.Invoke();
        }        
    }

    public void nextLvl()
    {
        Debug.Log("Iniciar próximo lvl");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject quitButton;

    private GameObject currentButton;

    private void Start()
    {
        currentButton = startButton;
        currentButton.GetComponent<Button>().Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentButton == startButton)
            {
                currentButton = optionsButton;
                currentButton.GetComponent<Button>().Select();
            }
            else if (currentButton == optionsButton)
            {
                currentButton = quitButton;
                currentButton.GetComponent<Button>().Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentButton == quitButton)
            {
                currentButton = optionsButton;
                currentButton.GetComponent<Button>().Select();
            }
            else if (currentButton == optionsButton)
            {
                currentButton = startButton;
                currentButton.GetComponent<Button>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            currentButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoCarta()
    {
        SceneManager.LoadScene("Carta");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


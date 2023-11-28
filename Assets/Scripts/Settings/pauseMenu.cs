using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject resumeButtonPM; //PM = Pause Menu
    public GameObject menuButtonPM;
    public GameObject quitButtonPM;
    public GameObject dialogoMultiObj;

    private GameObject currentButtonPM;

    void Start()
    {
        currentButtonPM = resumeButtonPM;
        currentButtonPM.GetComponent<Button>().Select();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentButtonPM == resumeButtonPM)
            {
                currentButtonPM = menuButtonPM;
                currentButtonPM.GetComponent<Button>().Select();
            }
            else if (currentButtonPM == menuButtonPM)
            {
                currentButtonPM = quitButtonPM;
                currentButtonPM.GetComponent<Button>().Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentButtonPM == quitButtonPM)
            {
                currentButtonPM = menuButtonPM;
                currentButtonPM.GetComponent<Button>().Select();
            }
            else if (currentButtonPM == menuButtonPM)
            {
                currentButtonPM = resumeButtonPM;
                currentButtonPM.GetComponent<Button>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            currentButtonPM.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        dialogoMultiObj.SetActive(true);

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        dialogoMultiObj.SetActive(false);

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuNovo");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        GetComponent<zKaiController>().enabled = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Restart1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Restart2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void Restart3()
    {
        SceneManager.LoadScene("lvl3");
    }
}

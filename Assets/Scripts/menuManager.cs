using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public string fase1;


    public GameObject principal, opts, controls, devs;
    void Start()
    {
        principal.SetActive(true);
        opts.SetActive(false);
        controls.SetActive(false);
        devs.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(fase1);
    }

    public void Quit()
    {
        Debug.Log("aaaaa");
        Application.Quit();
    }

    public void OpenOpts()
    {
        principal.SetActive(false);
        opts.SetActive(true);
    }
    public void BackOpts()
    {
        principal.SetActive(true);
        opts.SetActive(false);
    }

    public void OpenControls()
    {
        opts.SetActive(false);
        controls.SetActive(true);
    }

    public void BackControls()
    {
        opts.SetActive(true);
        controls.SetActive(false);
    }

        public void Go1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Go2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void Go3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void GoCarta()
    {
        SceneManager.LoadScene("Carta");
    }
}

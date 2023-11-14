using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOver;
    public GameObject completeLvlUI;
    public GameObject dialogoMultiObj;

    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        dialogoMultiObj.SetActive(false);
    }

    public void CompleteLevel()
    {
        completeLvlUI.SetActive(true);
                dialogoMultiObj.SetActive(false);

    }
}

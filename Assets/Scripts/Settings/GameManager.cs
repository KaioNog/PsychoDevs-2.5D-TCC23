using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOver;
    //public GameObject mainVCam;
    //public GameObject zoomVCam;

    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        //mainVCam.SetActive(false);
        //zoomVCam.SetActive(true);
    }
}

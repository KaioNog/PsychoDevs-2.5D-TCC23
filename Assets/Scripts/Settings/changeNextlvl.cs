using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeNextlvl : MonoBehaviour
{
    public void nextLvl()
    {
        Debug.Log("Iniciar próximo lvl");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private string nomeCena;

    public void comecarJogo()
    {
        SceneManager.LoadScene(nomeCena);
    }

}

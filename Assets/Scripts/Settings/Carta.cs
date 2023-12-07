using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carta : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(carta());
    }

    IEnumerator carta()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("lvl1");

    }
}

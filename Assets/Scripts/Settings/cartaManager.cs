using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cartaManager : MonoBehaviour
{
    public GameObject tutorialObj;
    public GameObject cartaObj;

    void Start()
    {
        StartCoroutine(carta());
    }

    IEnumerator carta()
    {
        Debug.Log("35seg de carta");
        yield return new WaitForSeconds(35f);
        StartCoroutine(tutorial());
    }

    IEnumerator tutorial()
    {
        cartaObj.SetActive(false);
        tutorialObj.SetActive(true);
        Debug.Log("10seg de tutorial");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("lvl1");
    }
}

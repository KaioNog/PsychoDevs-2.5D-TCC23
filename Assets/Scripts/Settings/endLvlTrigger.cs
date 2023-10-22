using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endLvlTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject nextLevelButton;
    public bool CanNextLvl;

    private GameObject currentButtonNL; //NL = Next Level

    void Start()
    {
        CanNextLvl = false;
        currentButtonNL = nextLevelButton;
        currentButtonNL.GetComponent<Button>().Select();
    }

    void Update()
    {
        if(CanNextLvl)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                currentButtonNL.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
        CanNextLvl = true;
            // Parar a música da fase
            FindObjectOfType<AudioManager>().Stop("TrilhaSonora");
            
            // Iniciar a música de vitória
            FindObjectOfType<AudioManager>().Play("Win");       
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

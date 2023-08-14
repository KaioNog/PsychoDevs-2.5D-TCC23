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
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

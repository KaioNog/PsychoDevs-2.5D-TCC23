using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //biblioteca canvas
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    /*public TextMeshProUGUI scoreText;
    public static int score;
    public int totalScore;

    public GameObject gameOver;
    public GameObject win;
    public GameObject creditos;
    public GameObject caixaTexto;

    public static GameController instance;

    [SerializeField] private string nomeLevel;*/

    /*void Start()
    {

        instance = this;

        UpdateScoreText();
        UpdateScoreTextMenos();
        
        totalScore = PlayerPrefs.GetInt("score");
        
        Debug.Log(PlayerPrefs.GetInt("score"));      
    }*/

    /*public void UpdateScoreText()
    {
        score++;
        scoreText.text = score.ToString ();

        totalScore++;
        PlayerPrefs.SetInt("score", totalScore);
    }

    public void UpdateScoreTextMenos()
    {
        score--;
        scoreText.text = score.ToString ();

        totalScore--;
        PlayerPrefs.SetInt("score", totalScore);
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ShowWin()
    {
        win.SetActive(true);
    }

    public void ShowCreditos()
    {
        creditos.SetActive(true);
    }

    public void NomeLevel()
    {
        SceneManager.LoadScene(nomeLevel);
    }     

    public void Dica()
    {
        caixaTexto.SetActive(false);
    }*/
}

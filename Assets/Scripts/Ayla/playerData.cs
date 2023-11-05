using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playerData : MonoBehaviour
{
    public static playerData playerDataInstance;
    public TextMeshProUGUI scoreMana;
    public int numberScoreMana = 0;
    
    private void Awake()
    {
        if(playerDataInstance == null)
        {
            playerDataInstance = this;
        }
    }

    public void AddScore(int m)
    {
        numberScoreMana += m;
        scoreMana.text = "Mana:  " + numberScoreMana;
    }

    public void subtractScore(int m)
     {
        numberScoreMana -= m;
        scoreMana.text = "Mana:  " + numberScoreMana;
    }   
}

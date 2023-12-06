using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TentacleControllerHidra : MonoBehaviour
{
    public GameObject tentacle1;
    public GameObject tentacle2;
    public GameObject tentacleHidra1;
    public GameObject tentacleHidra2Key;
    public GameObject tentacleHidra3;
    public GameObject tentacleHidra4;
    public GameObject endLvlWall;
    public GameObject headOctopus;
    public GameObject headOctopusEffect;
    private bool tentacleHidra2KeyDead = false;

    private void Start()
    {
        tentacleHidra2Key.GetComponent<enemyStats>().OnDeath += OnTentacleHidra2KeyDeath;
        tentacle2.GetComponent<enemyStats>().OnDeath += OnTentacleDeath;
    }

    private void OnTentacleDeath(int tentacleNumber)
    {
        Debug.Log("Tentáculo " + tentacleNumber + " morreu!");
        if (tentacleHidra1 != null && tentacleHidra2Key != null && tentacleHidra3 != null && tentacleHidra4 != null)
        {
            ActivateNewTentacles();
        }    
    }

    private void OnTentacleHidra2KeyDeath(int tentacleNumber)
    {
        Debug.Log("Tentáculo Hidra 2 Key morreu!");
        tentacleHidra2KeyDead = true;

        if (tentacleHidra2KeyDead)
        {
            headOctopus.SetActive(false);
            endLvlWall.SetActive(false);
            Instantiate(headOctopusEffect, headOctopus.transform.position, headOctopus.transform.rotation);
        }
    }

    private void ActivateNewTentacles()
    {
        tentacleHidra1.SetActive(true);
        tentacleHidra2Key.SetActive(true);
        tentacleHidra3.SetActive(true);
        tentacleHidra4.SetActive(true);
    }
}

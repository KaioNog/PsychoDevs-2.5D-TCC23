using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    #region Singleton

    public static playerManager instance;

    void Awake()
    {
        instance = this;
    }
    
    #endregion

    public GameObject player;
}

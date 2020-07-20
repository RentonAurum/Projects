using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    #region Singleton

    public static Enemy_Manager enemyMNG;

    private void Awake()
    {
        enemyMNG = this;
    }


    #endregion

    public GameObject enemyMelee;
    public GameObject enemyRanged;
    public GameObject enemyCaster;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    #region Singleton

    public static Camera_Manager instance;

    private void Awake()
    {
        instance = this;
    }


    #endregion

    public GameObject camera;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dogs_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public bool isOpenDoggo = false;

    public void ShowMenu()
    {
        if (ThisGO != null)
        {
            Animator animDog = ThisGO.GetComponent<Animator>();

            if (isOpenDoggo == false)
            {
                isOpenDoggo = true;
                animDog.SetBool("OpenDoggo", isOpenDoggo);
                Debug.Log("EnsommaDOG---TRUE");
            }
            else
            {
                isOpenDoggo = false;
                animDog.SetBool("OpenDoggo", isOpenDoggo);
                Debug.Log("EnsommaDOG---FALSE");
            }
        }
    }

}
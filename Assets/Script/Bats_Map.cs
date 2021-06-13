using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bats_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public Button batButton;
    public bool isOpenBat = false;

    public void ShowMenu()
    {
        if (ThisGO != null)

        {

            Animator animBat = ThisGO.GetComponent<Animator>();

            if (isOpenBat == false)
            {
                /*isOpenBoar = animBoar.GetBool("OpenBoar");*/
                isOpenBat = true;
                animBat.SetBool("OpenBat", isOpenBat);
                Debug.Log("EnsommaBAT---TRUE");
            }

            else if (isOpenBat == true)
            {
                isOpenBat = false;
                animBat.SetBool("OpenBat", isOpenBat);
                Debug.Log("EnsommaBAT---FALSE");
            }

        }
    }

}

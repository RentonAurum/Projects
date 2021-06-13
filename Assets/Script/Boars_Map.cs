using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boars_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public bool isOpenBoar = false;

    public void ShowMenu()
    {
        if (ThisGO != null)
        {
            Animator animBoar = ThisGO.GetComponent<Animator>();

            if (isOpenBoar == false)
            {
                isOpenBoar = true;
                animBoar.SetBool("OpenBoar", isOpenBoar);
                Debug.Log("EnsommaBOAR---TRUE");
            }
            else
            {
                isOpenBoar = false;
                animBoar.SetBool("OpenBoar", isOpenBoar);
                Debug.Log("EnsommaBOAR---FALSE");
            }

        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bears_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public bool isOpenBear = false;

    public void ShowMenu()
    {
        if (ThisGO != null)
        {
            Animator animBear = ThisGO.GetComponent<Animator>();

            if (isOpenBear == false)
            {
                isOpenBear = true;
                animBear.SetBool("OpenBear", isOpenBear);
                Debug.Log("EnsommaBEAR---TRUE");
            }
            else
            {
                isOpenBear = false;
                animBear.SetBool("OpenBear", isOpenBear);
                Debug.Log("EnsommaBEAR---FALSE");
            }

        }
    }

}

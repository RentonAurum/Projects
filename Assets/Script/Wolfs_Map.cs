using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wolfs_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public bool isOpenWolf = false;

    public void ShowMenu()

    {

        if (ThisGO != null)

        {
            Animator animWolf = ThisGO.GetComponent<Animator>();

            if (isOpenWolf == false)

            {
                /*isOpenBoar = animBoar.GetBool("OpenBoar");*/
                isOpenWolf = true;
                animWolf.SetBool("OpenWolf", isOpenWolf);
                Debug.Log("EnsommaWOLF---TRUE");
            }

            else

            {
                isOpenWolf = false;
                animWolf.SetBool("OpenWolf", isOpenWolf);
                Debug.Log("EnsommaWOLF---FALSE");
            }

        }
        
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chickens_Map : MonoBehaviour
{
    [Header("Slider Attributes")]

    public GameObject ThisGO;
    public bool isOpenChicken = false;

    public void ShowMenu()
    {
        if (ThisGO != null)

        {
            Animator animChicken = ThisGO.GetComponent<Animator>();

            if (isOpenChicken == false)

            {
                isOpenChicken = true;
                animChicken.SetBool("OpenChicken", isOpenChicken);
                Debug.Log("EnsommaCHICKEN---TRUE");
            }

            else

            {
                isOpenChicken = false;
                animChicken.SetBool("OpenChicken", isOpenChicken);
                Debug.Log("EnsommaCHICKEN---FALSE");
            }

        }
    }

}

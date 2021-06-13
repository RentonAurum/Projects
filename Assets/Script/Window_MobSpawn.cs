using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_MobSpawn : MonoBehaviour
{
    [Header("Slider Attributes")]
    public GameObject ThisGO;
    public GameObject PlayerSpawnOverlay;
    public GameObject CamOverlay;


    public bool enable = false;
    private int counter = 0;

    public void ShowMenu()
    {
        if (enable == true && counter == 1)
        {
            //Debug.Log("CAZZO");
            counter = 0;
            enable = false;
            ThisGO.SetActive(false);
            Debug.Log("FALsE");
        }
        else
        {
            if (PlayerSpawnOverlay.GetComponent<Window_PlayerSpawn>().enable == true)
            {
                PlayerSpawnOverlay.GetComponent<Window_PlayerSpawn>().enable = false;
                PlayerSpawnOverlay.transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log("TOLTO?");
            }
            if (CamOverlay.GetComponent<Window_Cam>().enable == true)
            {
                CamOverlay.GetComponent<Window_Cam>().enable = false;
                CamOverlay.transform.GetChild(0).gameObject.SetActive(false);
            }

            enable = true;
            counter = 1;
            ThisGO.SetActive(true);
            Debug.Log("TRUE");
        }
    }


 /*   public void ShowMenu()
    {

        if (ThisGO != null)
        {
            Animator anim = ThisGO.GetComponent<Animator>();
            Animator animPlayer = PlayerSpawnOverlay.GetComponent<Animator>();
            Animator animCam = CamOverlay.GetComponent<Animator>();

            bool playerIsOpen = animPlayer.GetBool("Open");
            bool camIsOpen = animCam.GetBool("Open");

            ////////////////////////////////////////////
            if (animPlayer.GetBool("Open") == true)
            {
                animPlayer.SetBool("Open", !playerIsOpen);
            }
            if (animCam.GetBool("Open") == true)
            {
                animCam.SetBool("Open", !camIsOpen);
            }

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
                Debug.Log("Ensomma");
            }

        }
    }*/

}

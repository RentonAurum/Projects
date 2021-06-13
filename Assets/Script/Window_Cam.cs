using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Cam : MonoBehaviour
{
    [Header("Slider Attributes")]
    public GameObject ThisGO;
    public GameObject MobSpawnOverlay;
    public GameObject PlayerSpawnOverlay;

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
            if (MobSpawnOverlay.GetComponent<Window_MobSpawn>().enable == true)
            {
                MobSpawnOverlay.GetComponent<Window_MobSpawn>().enable = false;
                MobSpawnOverlay.transform.GetChild(0).gameObject.SetActive(false);
            }

            enable = true;
            counter = 1;
            ThisGO.SetActive(true);
            Debug.Log("TRUE");
        }
    }


/*    public void ShowMenu()
    {
        if (ThisGO != null)
        {
            Animator anim = ThisGO.GetComponent<Animator>();
            Animator animMob = MobSpawnOverlay.GetComponent<Animator>();
            Animator animPlayer = PlayerSpawnOverlay.GetComponent<Animator>();

            bool mobIsOpen = animMob.GetBool("Open");
            bool playerIsOpen = animPlayer.GetBool("Open");
            ////////////////////////////////////////////
            if (animMob.GetBool("Open") == true)
            {
                animMob.SetBool("Open", !mobIsOpen);
            }
            if (animPlayer.GetBool("Open") == true)
            {
                animPlayer.SetBool("Open", !playerIsOpen);
            }
            ////////////////////////////////////////////
            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
                Debug.Log("Ensomma");
            }

        }
    }*/

}

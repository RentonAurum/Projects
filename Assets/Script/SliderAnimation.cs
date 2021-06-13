using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnimation : MonoBehaviour
{
    [Header("Slider Attributes")]
    public GameObject Menu;

    public void ShowMenu()
    {
        if (Menu != null)
        {
            Animator anim = Menu.GetComponent<Animator>();

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
                Debug.Log("Ensomma");
            }

        }
    }

}

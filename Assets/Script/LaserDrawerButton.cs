using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDrawerButton : MonoBehaviour
{
    public GameObject ThisGO;
    // Start is called before the first frame update
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
            enable = true;
            counter = 1;
            ThisGO.SetActive(true);
            Debug.Log("TRUE");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    //public GameObject CanvasStart;

    public void Enable(GameObject CanvasStart)

    {

        CanvasStart.SetActive(true);

    }

    public void Disable(GameObject CanvasStart)

    {

        CanvasStart.SetActive(false);

    }
}

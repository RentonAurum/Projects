using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDAmmo : MonoBehaviour
{
    public bool Firing;
    public int DisplayAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Firing && DisplayAmmo > 0)
        {
            Firing = true;
            DisplayAmmo--;
            Firing = false;
        }
        
    }
}

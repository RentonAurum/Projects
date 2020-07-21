using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ~ Al momento non serve assolutamente a nulla. Nessuna animazione fino ad una prossima modifica ~

public class Button_Animation : MonoBehaviour
{

    void Start()
    {
        
    }

    public void Button_Highlight()
    {
        GetComponent<Animation>().Play("Start");
    }

}

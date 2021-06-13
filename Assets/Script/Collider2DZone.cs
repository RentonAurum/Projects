using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PolygonCollider2D))]
public class Collider2DZone : MonoBehaviour
{

    private Image image;
    
    public Color oldColor;
    public Color hoverColor;
    public Color startColor;
    public Material zone;
    private int counter = 1;

    void Awake()
    {
        zone = GetComponent<Renderer>().material;
        image = GetComponent<Image>();
        zone.color = startColor;
    }

    private void OnMouseDown()
    {
        if (counter == 1)
        {
            hoverColor = Color.yellow;
            GetComponent<Renderer>().material.SetColor("_Color", hoverColor);
            counter = 2;
        }
        else if (counter == 2)
        
        {
            hoverColor = Color.red;
            GetComponent<Renderer>().material.SetColor("_Color", hoverColor);
            counter = 0;
        }
        else if (counter == 0)

        {
            hoverColor = startColor;
            GetComponent<Renderer>().material.SetColor("_Color", hoverColor);
            counter = 1;
        }
    }
}

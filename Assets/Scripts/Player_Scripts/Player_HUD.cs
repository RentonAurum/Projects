using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HUD : MonoBehaviour
{

    public Slider slide;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHP(float HP)

    {
        slide.maxValue = HP;
        slide.value = HP;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHP(float HP)

    {
        slide.value = HP;

        fill.color = gradient.Evaluate(slide.normalizedValue);
    }

}

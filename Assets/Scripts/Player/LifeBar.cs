using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private float life;
    private float lifeMax;

    public Movement player;

    private void Update()
    {
        sliderLenght();
    }

    void sliderLenght()
    {
        life = player.hp;
        lifeMax = player.hpMax;
        gameObject.GetComponent<Slider>().value = life / lifeMax;
    }
}

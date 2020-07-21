using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Enemy_LifeBar : MonoBehaviour
{
    private float life;
    private float lifeMax;
    Transform target;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
    }
    private void Update()
    {
        transform.LookAt(target);
    }

    private void LateUpdate()
    {
        sliderLenght();
    }

    void sliderLenght()
    {
        life = gameObject.GetComponentInParent<Enemy>().hp;
        lifeMax = gameObject.GetComponentInParent<Enemy>().hpMax;
        gameObject.GetComponentInChildren<Slider>().value = life / lifeMax;
    }

}

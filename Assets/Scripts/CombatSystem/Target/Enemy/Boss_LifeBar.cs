using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_LifeBar : MonoBehaviour
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
        life = gameObject.GetComponentInParent<Boss>().hp;
        lifeMax = gameObject.GetComponentInParent<Boss>().hpMax;
        gameObject.GetComponentInChildren<Slider>().value = life / lifeMax;
    }

}

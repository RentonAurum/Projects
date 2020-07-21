using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject fireShot;
    public List<GameObject> vfx = new List<GameObject>();
    public Gun gunRotation;

    // private GameObject SpawnEffect;
   // private float FireTime = 0;


    /*void Start()
    {
        SpawnEffect = vfx[0];
    }*/

   /* void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= FireTime)

        {
            FireTime = Time.time + 1 / SpawnEffect.GetComponent<BulletMove>().FireRate;
            CheckVFX();
        }


    }

    void CheckVFX()

    {
        GameObject vfx;

        if (fireShot != null)
        {

        }
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        MuzzleFlash.Stop();
        Shoot();
    }
    
    void Shoot()
    {
        StartCoroutine(WeaponEffect());
    }
    IEnumerator WeaponEffect()
    {
        MuzzleFlash.Play();
        yield return new WaitForEndOfFrame();
        MuzzleFlash.Stop();
    }
}

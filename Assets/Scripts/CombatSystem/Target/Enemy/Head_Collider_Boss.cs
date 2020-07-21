using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Collider_Boss : MonoBehaviour
{
    public Boss boss;

    private void Awake()
    {
        boss = GetComponentInParent<Boss>();
    }

}

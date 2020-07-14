using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Collider : MonoBehaviour
{
    public Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }


}

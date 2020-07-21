using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    public Animator walk;
    public Enemy enemy;

     void Update()
    {
        if (enemy.isWalking == true)
        {
            walk.SetBool("Walking", true);
        }
        if (enemy.isWalking == false)
        {
            walk.SetBool("Walking", false);
        }
        if (enemy.isAttacking == true)
        {
            walk.SetBool("Attack", true);
        }
        if (enemy.isAttacking == false)
        {
            walk.SetBool("Attack", false);
        }
        if (enemy.isDead == true)
        {
            walk.SetBool("Dead", true);
        }

    }
}

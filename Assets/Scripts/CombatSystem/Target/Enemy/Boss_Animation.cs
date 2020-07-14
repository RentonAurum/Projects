using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Animation : MonoBehaviour
{
    public Animator walk;
    public Boss boss;

    void Update()
    {
        if (boss.isWalking == true)
        {
            walk.SetBool("Walking", true);
        }
        if (boss.isWalking == false)
        {
            walk.SetBool("Walking", false);
        }
        if (boss.isAttacking == true)
        {
            walk.SetBool("Attack", true);
        }
        if (boss.isAttacking == false)
        {
            walk.SetBool("Attack", false);
        }
        if (boss.isDead == true)
        {
            walk.SetBool("Dead", true);
        }

    }
}

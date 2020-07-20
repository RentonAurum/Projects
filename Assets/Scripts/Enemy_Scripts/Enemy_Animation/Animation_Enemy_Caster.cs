using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Enemy_Caster : MonoBehaviour
{
    public Animator walk;
    public Enemy_AI_Caster enemy;
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
            walk.SetBool("Attacking", true);
        }
        if (enemy.isAttacking == false)
        {
            walk.SetBool("Attacking", false);
        }
        /*if (enemy.isDead == true)
        {
            walk.SetBool("Dead", true);
        }*/

    }
}

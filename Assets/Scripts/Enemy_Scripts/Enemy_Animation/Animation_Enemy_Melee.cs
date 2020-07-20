using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_Enemy_Melee : MonoBehaviour
{
    public Animator enemyAnim;
    public Enemy_AI_Melee enemy;
    public GameObject enemy_Sword_Coll;

    public Renderer rendering;
    public Material[] material;
    private float duration = 2.0f;
    float startTime;
    public float speed = 1f;

    public float smoothBlend = 2f;

    private void Start()
    {

        rendering = GetComponentInChildren<Renderer>();

    }

    void Update()
    {
        if (enemy.Standby == true)
        {
            enemyAnim.SetBool("Standby", true);
        }
        if (enemy.Standby == false)
        {
            enemyAnim.SetBool("Standby", false);
        }
        if (enemy.isWalking == true)
        {
            enemyAnim.SetBool("Walking", true);
        }
        if (enemy.isWalking == false)
        {
            enemyAnim.SetBool("Walking", false);
        }
        if (enemy.isAttacking == true)
        {
            enemyAnim.SetBool("Attack", true);
        }
        if (enemy.isAttacking == false)
        {
            enemyAnim.SetBool("Attack", false);
        }
        if (enemy.hasDodged == true)
        {
            enemyAnim.SetBool("JumpBehind", true);
        }
        if (enemy.hasDodged == false)
        {
            enemyAnim.SetBool("JumpBehind", false);
        }
        if (enemy.slash360 == true)
        {
            enemyAnim.SetBool("Slash360", true);
        }

        if (enemy.jumpDodge == false && enemy.fallDodge == true)

        {
            animFall();
        }

            if (enemy.isDead == true)

                {

                    if (gameObject.layer == 13)

                    {

                         float t = (Time.time - startTime) * speed;
                         rendering.material.Lerp(material[0], material[1], t);
                         Destroy(this.gameObject, 4f);

                    }

                enemyAnim.SetBool("Death", true);

            }

    }
    
    public void endAttack()
    {
        enemy.isAttacking = false;
    }

    public void endSlash360()
    {
        enemy.slash360 = false;
        enemyAnim.SetBool("Slash360", false);

    }

    public void softFall()
    {
        enemyAnim.SetBool("Fall", false);
    }

    public void animFall()

    {

            //Debug.LogError("KOASKDOKASODKSADO");
            enemyAnim.SetBool("JumpBehind", false);
            enemyAnim.SetBool("Fall", true);
        
    }

    public void SwordTrue()

    {

        enemy_Sword_Coll.SetActive(true);

    }

    public void SwordFalse()

    {

        enemy_Sword_Coll.SetActive(false);

    }

    public void SwitchMaterial()

    {


    }

}

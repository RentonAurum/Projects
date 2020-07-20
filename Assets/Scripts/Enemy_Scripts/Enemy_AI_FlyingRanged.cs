using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_FlyingRanged : Enemy_AI_Standard
{

    private float shotRate = 2.0f;
    private float shotTime;
    public GameObject arrow;
    public GameObject bow;

    protected override void Move()
    {

        //base.Move();
        if (Vector3.Distance(transform.position, target.position) <= rangeDistance)

        {
            // PUNTO DOVE SI FERMA PER ATTACCARE
            if (Vector3.Distance(transform.position, target.position) >= 8)
            {
                Debug.Log("Player Trovato! Mi muovo!");
                Prepare();
            }


            if (Vector3.Distance(transform.position, target.position) <= 8)
            {
                StartCoroutine(enemyAttack());
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > rangeDistance)
        {
            
        }

    }
    public IEnumerator enemyAttack()
    {
        yield return new WaitForSeconds(1f);

        if (Vector3.Distance(transform.position, target.position) <= 8)
        {

            shotTime += Time.deltaTime;

            if (shotTime > shotRate)
            {
                Debug.Log(enemyName + " TI STA ATTACCANDO!");
                Instantiate(arrow, bow.gameObject.transform.position, Quaternion.identity);
                shotTime = 0;
                // player.takeDmg (atkPower)
            }
            // isAttacking = false;
        }

    }
    void Prepare()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime * 3f);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

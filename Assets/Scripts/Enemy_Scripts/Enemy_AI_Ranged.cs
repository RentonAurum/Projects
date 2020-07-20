using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Ranged : Enemy_AI_Standard
{
    public Player_Manager PgManager;
    public Player_Stats PgStat;
    public enemyStat rangedStat;

    protected override void Start()
    {
        base.Start();
        PgStat = Player_Manager.instance.player.GetComponent<Player_Stats>();
        rangedStat.atk = 15;
        rangedStat.def = 5;
        rangedStat.hp = 20;
    }

    public override void takeDamage(float pgAtk)
    {
        //base.takeDamage(pgAtk);
        this.rangedStat.hp -= pgAtk - (int)(rangedStat.def / 2);
        Debug.Log(rangedStat.hp);
    }


    protected override void Update()
    {
        base.Update();

        if (rangedStat.hp <= 0)
        {
            Death();
        }
    }

    protected override void Move()
    {

        //base.Move();

        if (Vector3.Distance(transform.position, target.position) <= rangeDistance)

        {
            Debug.Log("Player Trovato! Mi muovo!");
            agent.SetDestination(target.position);
            if (Vector3.Distance(transform.position, target.position) <= 6)
            {
                Prepare();
                agent.SetDestination(transform.position);
                StartCoroutine(enemyAttack());
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > rangeDistance)
        {
            agent.SetDestination(initialSpot);
        }

    }

    public IEnumerator enemyAttack()
    {
        yield return new WaitForSeconds(1f);

        if (Vector3.Distance(transform.position, target.position) <= 6)
        {
            Debug.Log(enemyName + " TI STA ATTACCANDO!");
            // player.takeDmg (atkPower)
        }
        // isAttacking = false;
    }
    void Prepare()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-90, -90, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    /*protected override void Death()
    {
        base.Death();
    }*/

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Caster : Enemy_AI_Standard
{
    public bool isWalking = false;
    public bool isAttacking = false;

    private float shotRate = 1.7f;
    private float shotTime;
    public GameObject casterAttack;
    public GameObject Staff;

    public Player_Manager PgManager;
    public Player_Stats PgStat;
    public enemyStat rangedStats;


    protected override void Start()
    {
        base.Start();
        PgStat = Player_Manager.instance.player.GetComponent<Player_Stats>();
        //rangedStats.atk = 30;
        rangedStats.def = 10;
        rangedStats.hp = 40;
    }

    protected override void Move()
    {
        isWalking = true;
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
        isWalking = false;
        
        yield return new WaitForSeconds(0f);

        if (Vector3.Distance(transform.position, target.position) <= 8)
        {
            isAttacking = true;
            shotTime += Time.deltaTime;

            if (shotTime > shotRate)
            {
                //Debug.Log(enemyName + " TI STA ATTACCANDO! I danni sono : ");
                Instantiate(casterAttack, Staff.gameObject.transform.position, Quaternion.identity);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using Random = UnityEngine.Random;

public class Enemy_AI_Melee : Enemy_AI_Standard

{

    [Space]
    [Space]
    [Space]

    public Player_Combat pgCombat;
    public Player_Stats pgStat;
    public enemyStat meleeStat;

    [Space]
    [Space]
    [Space]

    public bool Standby;
    public bool isWalking;
    public bool isAttacking;
    public bool isDead;
    public bool jumpDodge;
    public bool fallDodge;
    public bool slash360;

/// <summary>
/// 
/// </summary>

    public bool hasDodged;
    public float randomDodge;

/// <summary>
/// 
/// </summary>

    public Vector3 jumpPos;
    public float speedTrans = 11f;

    [Space]
    [Space]
    [Space]

    public float distancePlayer;



    protected override void Start()

    {

        base.Start();
        pgStat = Player_Manager.instance.player.GetComponent<Player_Stats>();
        pgCombat = Player_Manager.instance.player.GetComponent<Player_Combat>();
        meleeStat.atk = 15;
        meleeStat.def = 5;
        meleeStat.hp = 200;

        transform.position = initialSpot;

    }

    public override void takeDamage(float pgAtk)

    {

        this.meleeStat.hp -= pgAtk - (int)(meleeStat.def / 2);
        GameObject DmgPoints = Instantiate(popOut_Dmg, pop, Quaternion.identity) as GameObject;
        DmgPoints.transform.GetChild(0).GetComponent<TextMeshPro>().text = pgAtk.ToString();
        
        if (meleeStat.hp <= 0)

        {

            isDead = true;
            Death();

        }

        else
            isDead = false;

    }

    protected override void Update()

    {

        base.Update();

        if (hasDodged == true)

        {

            isAttacking = false;

            //Debug.Log("Moving...");

            distancePlayer = Vector3.Distance(target.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, jumpPos, Time.deltaTime * speedTrans);

            if (distancePlayer >= 6.7 && (transform.position != jumpPos))
            
            {

                jumpDodge = false;
                fallDodge = true;
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;


            }

            if (transform.position == jumpPos)

            {

                transform.position = transform.position;

                fallDodge = false;
                hasDodged = false;
                slash360 = true;

            }

        }

    }

    protected override void Move()

    {

        if (isAttacking==true && Input.GetMouseButtonDown(0))

        {

            if (Random.Range(1,100) > 80)

            {
                isAttacking = false;
                hasDodged = true;

                jumpPos = transform.position + new Vector3(0, 0, 10);
                Debug.Log(Random.Range(1,100));

            }

        }

        else if (isDead == false && hasDodged == false && slash360 == false)

        {

            //gameObject.GetComponent<Rigidbody>().transform.position = gameObject.GetComponentInChildren<CapsuleCollider>().transform.position;
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;

            distancePlayer = Vector3.Distance(target.position, transform.position);


            if (distancePlayer <= rangeDistance && hasDodged == false)

            {
                distancePlayer = Vector3.Distance(target.position, transform.position);
                Standby = false;
                  Debug.Log("Player Trovato! Mi muovo!");
                if (isAttacking == false)
                  agent.SetDestination(target.position);

                isWalking = true;

            // PUNTO DOVE SI FERMA PER ATTACCARE

                if (distancePlayer <= agent.stoppingDistance)

                {
                    
                    isWalking = false;
                    isAttacking = true;

                    Prepare();
                    
                    agent.SetDestination(transform.position);

                        if (dmgDT >= dmgTime)

                        {
                            StartCoroutine(enemyAttack());
                            dmgDT = 0f;

                        }

                }

            }

            else

                {

                    if (transform.position == initialSpot)

                    {
                        
                        Standby = true;
                        isWalking = false;

                    }

                    else if(hasDodged == false && slash360 == true)
                    
                    {

                        isWalking = false;
                        fallDodge = false;

                    }

                    else if (distancePlayer >=12 )

                    {

                        agent.SetDestination(initialSpot);
                        Standby = false;
                        isWalking = true;
                        isAttacking = false;
               
                    }

            }

        }

    }
    protected override void Attack()

    {

        //base.Attack();

    }

    public IEnumerator enemyAttack()

    {

        yield return new WaitForSeconds(1f);

        if(distancePlayer <= agent.stoppingDistance)

            {

                //Debug.Log("lololol");
                isWalking = false;
                this.transform.LookAt(target.transform);

            }

    }
    void Prepare()

    {

        Quaternion rotEnemy = Quaternion.LookRotation(target.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotEnemy, Time.deltaTime);
        this.transform.LookAt(target.transform);

    }

    protected override void Death()

    {
        isAttacking = false;
        isWalking = false;
        Standby = false;
        isDead = true;
        base.Death();

    }

}

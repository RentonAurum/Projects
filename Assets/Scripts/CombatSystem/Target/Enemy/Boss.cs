using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    public float hp = 50f;
    public float hpMax = 50f;
    public float lookRadius = 10f; //raggio entro il quale ti vede
    public float lookRadiusEnemySound = 10f;
    public float attackPower = 1f;
    public float damageTime = 2f;
    float damageDeltaTime = 0f;
    bool canAttack = false;
    int dropChance;

    public Movement player;
    Transform target;
    NavMeshAgent agent;
    //public GameObject dropAmmo;
    //public GameObject dropLife;
    public bool isWalking;
    public bool isAttacking;
    public bool isDead;
    public float distance;
    public Gun gun;
    public Vector3 deathTransform;
    public Head_Collider_Boss head;
    public bool bossDefeated;

    private void Start()
    {
        target = PlayerManager.instance.player.transform; //prendo la posizione del giocatore
        agent = GetComponent<NavMeshAgent>();
        hp = hpMax;
        isWalking = false;
        isAttacking = false;
        bossDefeated = false;
    }

    private void Awake()
    {
        head = gameObject.GetComponentInChildren<Head_Collider_Boss>();
    }
    private void Update()
    {


        damageDeltaTime += Time.deltaTime;
        if (damageDeltaTime >= damageTime)
        {
            canAttack = true;
        }
        distance = Vector3.Distance(target.position, transform.position); //calcolo distanza tra giocatore e nemico



        if (distance <= lookRadius && isDead == false)
        {

            agent.SetDestination(target.position); //questa funzione fa inseguire una posizione


            //Inserire animazione

            isWalking = true;

            if (distance <= agent.stoppingDistance)
            {
                isWalking = false;

                faceTarget();
                agent.SetDestination(transform.position);
                if (canAttack == true)
                {
                    isAttacking = true;

                    StartCoroutine(attackPlayer());
                    damageDeltaTime = 0f;
                    canAttack = false;

                }
                //isAttacking = true;
            }

        }


        else
        {
            agent.SetDestination(transform.position); //fermare

            //Fermare animazione
            isWalking = false;
            isAttacking = false;
        }


    }


    public void TakeDamage(float amount)
    {
        Debug.Log("Aloa");
        hp -= amount;
        if (hp <= 0f)
        {
            deathTransform = gameObject.transform.position;
            agent.SetDestination(transform.position);
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()

    {
        bossDefeated = true;
        isWalking = false;
        isAttacking = false;
        isDead = true;
        agent.Stop();
        //transform.position = deathTransform;
        Destroy(gameObject.GetComponent<CapsuleCollider>());
        Destroy(gameObject.GetComponentInChildren<SphereCollider>());
        Destroy(gameObject.GetComponentInChildren<Canvas>().gameObject);
        yield return new WaitForSeconds(GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);

        //dropReward();
        Destroy(gameObject, 0.1f);
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-90, -90, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public IEnumerator attackPlayer()
    {
        yield return new WaitForSeconds(1f);
        if (distance <= agent.stoppingDistance)
        {
            player.takeDamage(attackPower);
        }
        isAttacking = false;
    }

   /* void dropReward()
    {
        dropChance = Random.Range(1, 11);
        if (dropChance <= 5)
        {
            GameObject dropAmmoClone = Instantiate(dropAmmo);
            dropAmmoClone.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            dropAmmoClone.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GameObject dropLifeClone = Instantiate(dropLife);
            dropLifeClone.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            dropLifeClone.transform.localScale = new Vector3(1, 1, 1);
        }

    }*/

}

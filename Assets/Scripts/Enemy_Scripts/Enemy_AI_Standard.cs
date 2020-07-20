using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI_Standard : MonoBehaviour
{
    //[SerializeField] protected private float hp;
    //[SerializeField] protected private float maxHP;

    [Space]
    [Space]
    [Space]

    [SerializeField] protected private string enemyName;
    [SerializeField] protected private float rangeDistance;
    [SerializeField] protected private float speed = 3f;

    [Space]
    [Space]
    [Space]

    [SerializeField] protected private float dmgDT = 0f;
    [SerializeField] protected private float dmgTime = 1.5f;
    public GameObject popOut_Dmg;

    [Space]
    [Space]
    [Space]

    //private Vector3 popOut_transform;

    public Rigidbody rb;

    /*protected private float enemy_caster_ATK;
    protected private float enemy_fly_rangedATK;*/
    /*protected private float atk;
    protected private float def;*/

    public struct enemyStat

    {
        public float atk;
        public float def;
        public float hp;
    }

    private enemyStat enStat;

    protected private Vector3 popOut_transform;
    protected private Vector3 pop = new Vector3();

    protected private Vector3 initialSpot;
    protected private Transform target;

    protected private NavMeshAgent agent;
    protected private NavMeshAgent agentFly;




    virtual public void takeDamage(float pgAtk)
    {
        
    }

    private void Awake()
    {

    }

    protected virtual void Start()

    {

        //popOut_transform = transform.position + new Vector3 (Random.Range(- transform.position.z -8 ,transform.position.z +8), Random.Range (transform.position.y - 3, transform.position.y + 4));

        // rendering = GetComponentInChildren<Renderer>();
        //shaderDeath = Shader.Find("Shader_Dissolve");
        /*rendering.enabled = true;
        rendering.sharedMaterial = material[0];*/

        /*popOut_transform.y += 2f;
        popOut_transform.z -= 0.85f;*/

        rb = GetComponent<Rigidbody>();

        initialSpot = this.gameObject.transform.localPosition;
        target = Player_Manager.instance.player.transform;
        agent = this.GetComponent<NavMeshAgent>();
        agentFly = this.GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {

        dmgDT = dmgDT + Time.deltaTime;

        pop.z = Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f);
        pop.y = Random.Range(transform.position.y + 0.5f, transform.position.y + 1.8f);
        pop.x = 1.5f;

        Move();


        // CONDIZIONI VITALI DEL NEMICO. DA COLLEGARE CON LE VARIABILI DEL PG PRINCIPALE.
    }

    protected virtual void jumpTranslate()
    {

    }

    protected virtual void Move()

    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeDistance);
    }

    protected virtual void Attack()
    {
       
    }

    protected virtual void Death()
    {

        rb.isKinematic = true;
        rb.detectCollisions = false;

    }

}
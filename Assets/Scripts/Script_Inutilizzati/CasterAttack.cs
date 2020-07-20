using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterAttack : MonoBehaviour
{
    [SerializeField] private float shotSpd = 0;
    [SerializeField] private float maxLife = 1.0f;
    private Transform target;
    private float lifeInTime;
    public GameObject destroyEff;

    public Enemy_AI_Caster casterStats;
    private Player_Stats PlayerStat;
    void Start()
    {
        target = Player_Manager.instance.player.transform;
        PlayerStat = Player_Manager.instance.player.GetComponent<Player_Stats>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, shotSpd * Time.deltaTime);
        lifeInTime += Time.deltaTime;
        if (lifeInTime >=maxLife)
        {
            //Instantiate(destroyEff,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            casterStats.rangedStats.atk = 30;
            other.gameObject.GetComponent<Player_Stats>().takeDamage(casterStats.rangedStats.atk);
            Debug.Log("Danni : " + casterStats.rangedStats.atk);
            Instantiate(destroyEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

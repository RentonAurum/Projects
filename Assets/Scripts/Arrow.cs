using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float shotSpd;
    [SerializeField] private float maxLife = 1.0f;
    private Transform target;
    private float lifeInTime;
    public GameObject destroyEff;

    void Start()
    {
        target = Player_Manager.instance.player.transform;
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
            //Instantiate(destroyEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

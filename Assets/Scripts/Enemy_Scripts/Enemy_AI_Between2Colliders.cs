using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Between2Colliders : Enemy_AI_Standard
{
    private bool MovingRight = true;
    public float EnemySpeed;

    public bool isWalking;

    protected override void Move()
    {
        if (MovingRight)

        {
            isWalking = true;
            transform.Translate(0, 0, 2 * Time.deltaTime * EnemySpeed);
            transform.localScale = new Vector3(1, 1, 1);
        }

        else

        {
            isWalking = true;
            transform.Translate(0, 0, -2 * Time.deltaTime * EnemySpeed);
            transform.localScale = new Vector3(1, 1, -1);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Turn"))

            {

                if (MovingRight)

            {
                //Debug.Log("Ok");
                MovingRight = false;

            }

                else

            {
                //Debug.Log("Ok2");
                MovingRight = true;

            }

                
        }

    }

}

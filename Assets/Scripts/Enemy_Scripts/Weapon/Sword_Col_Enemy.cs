using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Col_Enemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player_Stats>().takeDamage(GameObject.Find("Enemy_Ground_Melee").GetComponent<Enemy_AI_Melee>().meleeStat.atk);
            Debug.Log("Player Colpito!");
            gameObject.SetActive(false);
        }

    }
}

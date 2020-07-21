using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor3 : MonoBehaviour
{
    public Animator open;
    public Gun gun;
    public Boss boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && boss.bossDefeated == true)
        {
            open.SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open.SetBool("Open", false);
        }
    }
}

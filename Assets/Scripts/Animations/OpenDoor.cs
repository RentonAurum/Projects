using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OpenDoor : MonoBehaviour
{
    public Animator open;
    public Gun gun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gun.score>=100)
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

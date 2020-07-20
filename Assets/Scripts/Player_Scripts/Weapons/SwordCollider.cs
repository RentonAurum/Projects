using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    //public Camera_Shake CM;
    private Camera_Manager Cam;

    private void OnTriggerEnter(Collider other)

    {
        if(other.gameObject.CompareTag ("Enemy"))

        {

            other.GetComponentInParent<Enemy_AI_Standard>().takeDamage(Player_Manager.instance.player.GetComponent<Player_Stats>().atk);
            Camera_Manager.instance.camera.GetComponent<Camera_Shake>().CameraShake( 1f , 0.1f );
            gameObject.SetActive(false);
        }

    }

}

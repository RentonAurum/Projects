using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;
    public float smoothness;


    private void Awake()
    {
        //playerTransform = Player_Manager.instance.player.transform;
        cameraOffset = transform.position - playerTransform.position;
        
    }

    private void Update()
    {
        Vector3 newPosition = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothness);
        
    }
}

using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Camera_Shake : MonoBehaviour
{
    //public static Camera_Shake Instance { get; private set; }

    private float shakeTime;

    private CinemachineVirtualCamera VCam;

    private void Awake()
    {
        //Instance = this;
        VCam = GetComponent<CinemachineVirtualCamera>();
    }
    public void CameraShake (float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CM_Basic = VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CM_Basic.m_AmplitudeGain = intensity;
        shakeTime = time;
    }


    void Update()

    {
        if (shakeTime > 0)
        
        {

            shakeTime -= Time.deltaTime;

            if (shakeTime <= 0f)

            {

                CinemachineBasicMultiChannelPerlin CM_Basic = VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CM_Basic.m_AmplitudeGain = 0f;

            }

        }

    }

}

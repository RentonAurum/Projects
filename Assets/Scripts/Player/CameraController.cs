using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ~ Imposto la sensitività e il limite degli assi del cursor ~
    [SerializeField]
    float MouseSense = 0;
    float AxisLimit;

    // ~ Commenti sotto : Per modificare il cursore più avanti ~

    /*public CursorMode cursorMode = CursorMode.Auto;
    public Texture2D Texture;
    public Vector2 hotspot = Vector2.zero;*/

    [SerializeField]
    Transform Pg; // ~ Ricordarsi di inserire anche pgArm per la camera sulle braccia ~
    Transform Gun;

    void Awake()

    {
        gameObject.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Start()
    {
        
    }

    void Update()

    {

            //Cursor.lockState = CursorLockMode.Locked;
            gameObject.GetComponent<CameraController>().enabled = true;
            CameraRotation();

    }

    // ~ Le stringhe commentate sotto serviranno per implementare la camera con il braccio ~

    void CameraRotation()

    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotationX = mouseX * MouseSense;
        float rotationY = mouseY * MouseSense;

        AxisLimit -= rotationY;

        Vector3 RotationPlayer = Pg.transform.rotation.eulerAngles;

        //Vector3 RotationPlayerArm = playerArm.transform.rotation.eulerAngles;

        RotationPlayer.x -= rotationY;
        RotationPlayer.y += rotationX;

        // RotationPlayerArm.x = rotationY;
        //RotationPlayerArm.z = 0;

        if (AxisLimit > 90)

        {
            AxisLimit = 90;
            RotationPlayer.x = 90;

        }

        else if (AxisLimit < -90)

        {
            AxisLimit = -90;
            RotationPlayer.x = 270;
        }

            //playerArm.rotation = Quaternion.Euler(RotationPlayerArm);
            Pg.rotation = Quaternion.Euler(RotationPlayer);
        //Gun.rotation = Quaternion.Euler(RotationPlayer);

    }

}

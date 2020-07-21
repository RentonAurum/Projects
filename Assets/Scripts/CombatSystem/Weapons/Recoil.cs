using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 RecoilOn;
    Vector3 InitialAxis;

    // Start is called before the first frame update
    void Start()
    {
        InitialAxis = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown (0))

            RecoilUp();

        else if (Input.GetMouseButtonUp(0))

            RecoilDown();

    }

    private void RecoilUp()
    {
        transform.localEulerAngles += RecoilOn;
    }

    private void RecoilDown()
    {
        transform.localEulerAngles = InitialAxis;
    }

}

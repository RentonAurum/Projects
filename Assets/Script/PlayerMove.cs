using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

        rb.isKinematic = true;

    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }

}



/*private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    void Update()
    {
        if (isBeingHeld == true)
        {
            Debug.Log("DIOPORCONE");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            
        {
            Debug.Log("DIOPORCONE ON THE ROAD");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }*/
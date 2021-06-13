using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDrawer : MonoBehaviour
{

    [Header("Laser Attributes")]


    public Camera cam = null;
    public LineRenderer lineRenderer = null;
    private Vector3 mousePos;
    private Vector3 Pos;
    private Vector3 previousPos;
    public List<Vector3> linePositions = new List<Vector3>();
    public float minimumDistance = 0.05f;
 
    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
            Debug.Log("CIAONE");
                linePositions.Clear();
                mousePos = Input.mousePosition;
                mousePos.z = 10;
                Pos = cam.ScreenToWorldPoint(mousePos);
            }
            else
              if (Input.GetMouseButton(0))
            {
                mousePos = Input.mousePosition;
                mousePos.z = 10;
                Pos = cam.ScreenToWorldPoint(mousePos);
                linePositions.Add(Pos);
                lineRenderer.positionCount = linePositions.Count;
                lineRenderer.SetPositions(linePositions.ToArray());
            }
            else
                if (Input.GetMouseButtonUp(0))
            {
                //FollowManager.instance.makePlayersFollowPath(linePositions);
            }
        }
}
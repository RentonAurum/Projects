using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSpawn : MonoBehaviour
{

    //public Camera cam = null;
    //public LineRenderer lineRenderer = null;
    public Camera cam = null;
    private Vector3 mousePos;
    private Vector3 Pos;
    //public List<Vector3> linePositions = new List<Vector3>();
    //public float minimumDistance = 0.05f;

    public GameObject playerChoice;
    public GameObject overlay;

    public Image greenPlayer;

    void Start()
    {
        playerChoice = GetComponent<GameObject>();
        overlay = GetComponent<GameObject>();
    }
    public void Overlay()
    {
        Debug.Log("GNAGNA");
        Debug.Log(gameObject.tag);

        if (this.gameObject.tag == "Green")

        {
            Debug.Log("GIANLUCA DAI CAZZO");
            overlay.SetActive(true);

            if (this.gameObject.tag == "Green")
            {
                Debug.Log("AH FROCIO");
                this.gameObject.SetActive(true);
            }

        }
    }
}
    /*public void PlayerSpawnFunc()
    {
        Debug.Log("GREEN");
        mousePos = Input.mousePosition;
        Pos = cam.ScreenToWorldPoint(mousePos);
        Image greenP = Instantiate(greenPlayer, Pos, Quaternion.identity) as Image;
    }*/
using GameFlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{

    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rt.localScale.x < 1.8f)
        {
            rt.localScale = new Vector3(rt.localScale.x + 0.02f, rt.localScale.y + 0.02f, rt.localScale.z);
        }

    }
}

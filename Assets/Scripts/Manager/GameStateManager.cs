using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public enum gameStates
    {
        play,
        slow,
        pause,
        gameOver
    }

    public gameStates state;
    public GameObject text;
    public float slowFactorDeath;
    private Player_Manager pg;
    private Player_Stats pgStats;
    private float sizeX;
    public float maxSize;
    public float elapsedTime;
    public float fadeTime;

    private void Start()
    {
        state = gameStates.play;
        pgStats = Player_Manager.instance.player.GetComponent<Player_Stats>();   
        slowFactorDeath = 0.6f;
    }

    private void Update()
    {
        if (pgStats.isdead == true)
        {
            state = gameStates.gameOver;
            Time.timeScale = slowFactorDeath;
            text.SetActive(true);
            sizeX = text.GetComponent<RectTransform>().localScale.x;
            if (sizeX > maxSize)
            {
                slowFactorDeath = 0f;
            }
        }

    }


    /*public void timeManipulation()
    {
        if (state == gameStates.pause || state == gameStates.pause)
        {
            slowFactor = 0f;
        }
        else if (state == gameStates.play)
        {
            slowFactor = 1;
        }
        Time.timeScale = slowFactor;
    }*/
}

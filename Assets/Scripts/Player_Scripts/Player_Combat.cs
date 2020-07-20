using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Player_Animations anim;
    public Player_Movements movements;
    public int clicksCount = 0;
    public int kickCount = 0;
    float lastClickTime = 0f;
    public float maxComboDelay = 4f;

    private void Update()
    {
        if(Time.time - lastClickTime > maxComboDelay)
        {
            clicksCount = 0;
            kickCount = 0;
        }
        if(Input.GetMouseButtonDown(0) && movements.state != Player_Movements.playerStates.landing)
        {
            lastClickTime = Time.time;
            clicksCount++;
            anim.playerAnimator.SetBool("SwordSlash", true);
            clicksCount = Mathf.Clamp(clicksCount, 0, 3);
        }
        if (Input.GetMouseButtonDown(1) && movements.state != Player_Movements.playerStates.landing && clicksCount==0)
        {
            lastClickTime = Time.time;
            kickCount++;
            anim.playerAnimator.SetBool("Kick", true);
            kickCount = Mathf.Clamp(kickCount, 0, 1);
        }
    }

    





    // Vecchio Codice 2
    /*public Player_Animations anim;
    public Player_Movements movements;
    public GameObject swordColl;
    public int clickCount=0;
    public float delayClick=1f;
    public float clickTime = 0f;


    
    private void Update()
    {
        if ((delayClick< Time.time - clickTime) && Input.GetMouseButtonDown(0) && movements.state != Player_Movements.playerStates.landing) 
        {
            clickTime = Time.time;
            swordColl.SetActive(true);
            swordSlash();
        }
        if (delayClick < Time.time - clickTime)
        {
            swordColl.SetActive(false);
        }

        
    }

    void swordSlash()
    {
        //Play Animation
        anim.triggerSwordSlash();
        //Detect Enemies

        //Damage Enemies
        
    }*/



    //---Vecchio Codice ---//


    /*
    // Enumeratore degli stati di combattimento
    public enum combatStates
    {
        swordSlash,
        kick,
        none
    }

    //Dichiarazione Variabili

    public combatStates combatState;

    //Passaggio Componenti
    public Player_Movements playerState;

    void Awake()
    {
        // Inizializzazione
        combatState = combatStates.none;
    }

    void Update()
    {
        slash();

        kick();
    }

    // Funzioni

    private void slash()
    {
        if(playerState.state==Player_Movements.playerStates.standing && Input.GetMouseButtonDown(0))
        {
            combatState = combatStates.swordSlash;
        }
        else
        {
            combatState = combatStates.none;
        }
    }

    private void kick()
    {
        if (playerState.state == Player_Movements.playerStates.standing && Input.GetMouseButtonDown(1))
        {
            combatState = combatStates.kick;
        }
    }

    IEnumerator waitForAnimationEnding()
    {
        //Debug.Log(GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(2);
    } */
}

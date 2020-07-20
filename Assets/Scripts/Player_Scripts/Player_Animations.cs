using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    public Animator playerAnimator;
    public Player_Movements player;
    public Player_Combat combat;
    public Player_Stats stats;
    public GameObject swordColl;
    public GameObject footColl;
    
    private void Update()
    {
        if (player.state == Player_Movements.playerStates.walking)
        {
            playerAnimator.SetBool("Walking", true);
        }
        if (player.state!=Player_Movements.playerStates.walking)
        {
            playerAnimator.SetBool("Walking", false);
        }
        if (player.state == Player_Movements.playerStates.jumping)
        {
            playerAnimator.SetBool("Jumping", true);
        }
        if (player.state != Player_Movements.playerStates.jumping)
        {
            playerAnimator.SetBool("Jumping", false);
        }
        if (player.state == Player_Movements.playerStates.doubleJumping)
        {
            playerAnimator.SetBool("Double", true);
        }
        if (player.state != Player_Movements.playerStates.doubleJumping)
        {
            playerAnimator.SetBool("Double", false);
        }
        if (player.state == Player_Movements.playerStates.running)
        {
            playerAnimator.SetBool("Running", true);
        }
        if (player.state != Player_Movements.playerStates.running)
        {
            playerAnimator.SetBool("Running", false);
        }
        if (player.state == Player_Movements.playerStates.falling)
        {
            playerAnimator.SetBool("Falling", true);
        }
        if (player.state != Player_Movements.playerStates.falling)
        {
            playerAnimator.SetBool("Falling", false);
        }
        if (player.state == Player_Movements.playerStates.landing)
        {
            playerAnimator.SetBool("Landing", true);
        }
        if (player.state != Player_Movements.playerStates.landing)
        {
            playerAnimator.SetBool("Landing", false);
        }

        if (stats.isdead == true)
        {
            playerAnimator.SetTrigger("Dead");
        }
        
        /*if (combat.combatState == Player_Combat.combatStates.swordSlash)
        {
            playerAnimator.SetBool("SwordSlash", true);
        }
        if (combat.combatState != Player_Combat.combatStates.swordSlash)
        {
            playerAnimator.SetBool("SwordSlash", false);
        }*/

        
    }

    public void return1()
    {
        if (combat.clicksCount >= 2)
        {
            playerAnimator.SetBool("SwordSlash2", true);
        }
        else
        {
            swordColl.SetActive(false);
            playerAnimator.SetBool("SwordSlash", false);
            combat.clicksCount = 0;
        }
    }

    public void return2()
    {
        if (combat.clicksCount >= 3)
        {
            playerAnimator.SetBool("SwordSlash3", true);
        }
        else
        {
            swordColl.SetActive(false);
            playerAnimator.SetBool("SwordSlash", false);
            playerAnimator.SetBool("SwordSlash2", false);
            combat.clicksCount = 0;
        }
    }

    public void return3()
    {
        swordColl.SetActive(false);
        playerAnimator.SetBool("SwordSlash", false);
        playerAnimator.SetBool("SwordSlash2", false);
        playerAnimator.SetBool("SwordSlash3", false);
        combat.clicksCount = 0;

    }

    public void returnKick1()
    {
        if (combat.clicksCount>=1)
        {
            footColl.SetActive(false);
            swordColl.SetActive(true);
            playerAnimator.SetBool("KickSlash", true);
        }
        else
        {
            footColl.SetActive(false);
            playerAnimator.SetBool("Kick", false);
            combat.kickCount = 0;
        }
        
    }

    public void returnKickSlash1()
    {
        swordColl.SetActive(false);
        playerAnimator.SetBool("Kick", false);
        playerAnimator.SetBool("KickSlash", false);
        combat.kickCount = 0;
        combat.clicksCount = 0;
    }

    public void swordCollOn()
    {
        swordColl.SetActive(true);
    }

    public void swordCollOff()
    {
        swordColl.SetActive(false);
    }

    public void footCollOn()
    {
        footColl.SetActive(true);
    }

    public void footCollOff()
    {
        footColl.SetActive(false);
    }
}

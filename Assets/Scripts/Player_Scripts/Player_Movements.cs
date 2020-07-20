using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movements : MonoBehaviour
{
    
    // Enumeratore degli stati di gioco 

    public enum playerStates
    {
        standing,
        walking,
        running,
        jumping,
        doubleJumping,
        falling,
        landing,
        sliding,
        dead
    }

    // Dichiarazione Variabili

    public playerStates state;

    float posY, posZ;

    private Vector3 moveDirection;
    public float speed;
    public float walkingSpeed= 7f;
    public float runningSpeed = 10f;

    public float gravity = -9.81f;      //---Variabili Salto e Caduta---//
    public float jumpHeight = 4f;       //---//
    public int jumpCount = 1;           //---//
    Vector3 velocity;                   //---//
    public float inAirSpeed=4f;

    public Transform groundCheck;        //---Variabili controllo terreno---//
    public float groundDistance = 0.1f;  //---//
    public LayerMask groundMask;         //---//
    public bool isGrounded;              //---//

    public LayerMask enemyMask;
    public bool isOnEnemy;

    // Passaggio Componenti
    
    private CharacterController controller;
    private Player_Manager player;
    private Player_Combat combatState;
    private Player_Stats pgStats;

    // Start ed Update

    void Awake()
    {
        // Inizializzazione
        state = playerStates.standing;
        controller = GetComponent<CharacterController>();
        pgStats = gameObject.GetComponent<Player_Stats>();
    }

    private void Update()
    {
        //Freeze X axis
        //posY = transform.position.y;
        //posZ = transform.position.z;
        //transform.position = new Vector3(0f, posY, posZ);

        if (state != playerStates.dead)
        {
            //Speed

            speedChoice();

            // Ground Checking
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // Is player on Enemy check
            isOnEnemy = Physics.CheckSphere(groundCheck.position, groundDistance, enemyMask);
            if (isOnEnemy)
            {
                state = playerStates.sliding;
            }

            // Salto
            jump();

            if (velocity.y > 0)
            {
                if (jumpCount == 0)
                {
                    state = playerStates.jumping;
                }
                else
                {
                    state = playerStates.doubleJumping;
                }

            }

            // Caduta

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            if (velocity.y < 0 && !isGrounded && !isOnEnemy)
            {
                if (jumpCount == 1) //se sto cadendo posso fare un solo salto
                {
                    jumpCount--;
                }
                state = playerStates.falling;
            }

            // Camminata

            walkAndRun();

            // Movimento

            controller.Move(moveDirection * speed * Time.deltaTime);

            // Atterraggio

            landing();

            // Morte

            if (pgStats.isdead == true)
            {
                state = playerStates.dead;
            }
        }

        

    }

    //Funzioni

    private void walkAndRun()
    {
        float x=0;       
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (speed == walkingSpeed)
            {
                state = playerStates.walking;
            }
            else if(speed==runningSpeed)
            {
                 state = playerStates.running;
            }
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            moveDirection = Vector3.zero;
            state = playerStates.standing;
        }
        x = Input.GetAxis("Horizontal");
        moveDirection = transform.forward* x;

        // Facing
        if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, -1);
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount>-1) //doppio salto
        {
            jumpCount--;
            if (state == playerStates.running)
            {
                velocity.z = runningSpeed*transform.localScale.z*0.55f;
            }
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
    }

    private void landing ()
    {
            if (isGrounded && velocity.y < 0 && moveDirection.z == 0)
            {
                state = playerStates.standing;
                jumpCount = 1;
                velocity.z = 0;
            }
            else if (isGrounded && velocity.y < 0 && moveDirection.z != 0)
            {
                if (speed == walkingSpeed)
                {
                    state = playerStates.walking;
                    velocity.z = 0;
                }
                else if (speed == runningSpeed)
                {
                    state = playerStates.running;
                    velocity.z = 0;
                }

                jumpCount = 1;
            }       
    }

    private void speedChoice()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = runningSpeed;
        }
        else if ((velocity.y < 0 && !isGrounded) || velocity.y > 0)
        {
            speed = inAirSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }
    }

    IEnumerator waitForAnimationEnding()
    {
        //Debug.Log(GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }


}   
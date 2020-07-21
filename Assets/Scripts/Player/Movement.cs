using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // ~ Collider
    CapsuleCollider PgCollider;
    float initialHeight;
    public float HeightDown;

    private CharacterController controller;

    //GameObject target;

    public float hp = 0f;
    public float hpMax = 10f;
    public float Speed = 0f;
    public float WalkingSpeed = 0f;
    public float RunningSpeed = 0f;
    public float gravity = 0f;
    public float jumpHeight = 0f;
    private float descentGravity = 0f;

    public bool isThereDropAmmo;
    public bool isThereDropLife;

    public RectTransform panelGameOver;
    public Text txtGameover;
    public Image aim; 

    private Vector3 moveDirection = Vector3.zero;

    public GameObject GunPause;
    public GameObject CameraPause;
    public static bool GamePause = false;

    public AudioSource LootAudio;
    public AudioClip LootSound;

    // ~ Accedo alla componente CharacterController e la assegno alla variabile "controller" che ci servirà per muovere il
    //   nostro personaggio. Preferiamo usare il CharacterController al Rigidbody in questo caso in quanto più versatile
    //   per il movimento del nostro personaggio e le collisioni, quindi la sua risposta agli altri oggetti ~

    void Awake()

    {

        controller = GetComponent<CharacterController>();
        hp = hpMax;
        isThereDropAmmo = false;
        isThereDropLife = false;
    }

    void Start()
    {
        /*PgCollider = GetComponent<CapsuleCollider>();
        initialHeight = PgCollider.height;*/
    }

    // ~ Imposto il movimento del Player secondo la gravità, velocità e gli assi, e controllo se è sul terreno ~

    void Update()
    {
        // ~ Crouch

        /*if (Input.GetKeyDown(KeyCode.C))
            Crouch();

        else if (Input.GetKeyDown(KeyCode.C))
            Up();*/

        // ~ Walk And Run

        walkAndRun();

        // ~ Jump

        jump();

        // ~ Drop

        dropLifePickUp();

        // ~ GameOver!

        if (hp <= 0)
        {
            gameOver();
        }

    }

    /*void Crouch()

    {
        PgCollider.height = HeightDown;
    }

    void Up()
    {
        PgCollider.height = initialHeight;
    }*/

    void walkAndRun()
    {
        if (controller.isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0f, moveZ);

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))

            {

                Debug.Log("Tiene premuto");
                Speed = RunningSpeed;

            }
            else
            {
                Speed = WalkingSpeed;
            }
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection.y = 0;
                moveDirection *= Speed;
        }
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)

        {
            moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
        }

        if(controller.isGrounded || moveDirection.y > 0)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (moveDirection.y <= 0)
        {
            descentGravity = gravity;
            descentGravity += 1000 * Time.deltaTime;
            moveDirection.y -=descentGravity*Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void takeDamage(float damage)
    {
        hp -= damage;
    }

    public void gameOver()
    {

            panelGameOver.gameObject.SetActive(true);
            Debug.Log("GameOver");
            Pause();          
        
    }
    void restart()
    {
        SceneManager.LoadScene("MainMenu"); //Provvisorio
    }

    void dropLifePickUp()
    {
        if (isThereDropLife == true)
        {
            hp += 5;
            if (hp > hpMax)
            {
                hp = hpMax;
            }
            isThereDropLife = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag=="Drop Ammo")
        {
            LootAudio = GetComponent<AudioSource>();
            LootAudio.PlayOneShot(LootSound);
            isThereDropAmmo = true;
            Destroy(other.gameObject);
        }
        if(other.tag=="Drop Life")
        {
            LootAudio = GetComponent<AudioSource>();
            LootAudio.PlayOneShot(LootSound);
            isThereDropLife = true;
            Destroy(other.gameObject);

        }
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GunPause.GetComponent<Gun>().enabled = false;
        CameraPause.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0f;
        GamePause = true;
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            GamePause = false;
            restart();
        }
    }
}
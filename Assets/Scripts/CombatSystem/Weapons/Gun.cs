using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour

{
    // ~ Recoil

    public Vector3 RecoilOn;
    Vector3 InitialAxis;
    Vector3 InitialAxisHand;

    public Transform Hand;

    public Text AmmoDisplay;
    public Text MaxAmmoDisplay;
    public Text ScoreDisplay;

    public Camera fireCam;

    // ~ Suoni

    private AudioSource Sound;
    private AudioSource SoundReload;
    public AudioClip ReloadSound;
    public AudioClip HeadShot;

    // ~ Danno e Raggio dell'Arma

    public float dmg = 5f;
    public float range = 50f;

    // ~ Effetti Particellari

    public GameObject bullet;
    public GameObject ImpactEffect;
    public ParticleSystem MuzzleFlash;

    // ~ Dichiarazioni per la ricarica

    public bool isReloading = false;
    public int MaxAmmo = 8;
    public int CurrentAmmo = 0;
    public float reloading = 0.2f;

    // ~ Animator

    public Animator animator;
    public Animator HandAnimator;

    // ~ Score
    public int score;

    // ~ Drop
    public Movement player;

    void Start()

    {
        InitialAxis = transform.localEulerAngles;

        InitialAxisHand = Hand.localEulerAngles;

        score = 0;
        
    }

    void Update()

    {
        MaxAmmoDisplay.text = MaxAmmo.ToString();
        AmmoDisplay.text = CurrentAmmo.ToString();
        ScoreDisplay.text = score.ToString();

        if (isReloading)
        {
            return;
        }

        if (Input.GetKey("r") && CurrentAmmo < 8 && MaxAmmo > 0 && !Input.GetKey(KeyCode.LeftShift))

        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0 && !Input.GetKey(KeyCode.LeftShift))

        {

            transform.localEulerAngles += RecoilOn;
            Hand.localEulerAngles += RecoilOn;
            Fire();
        }

        else if (Input.GetMouseButtonUp(0))

        {

            transform.localEulerAngles = InitialAxis;
            Hand.localEulerAngles = InitialAxisHand;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))

        {
            animator.SetBool("Running", true);
            HandAnimator.SetBool("Running", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))

        {
            animator.SetBool("Running", false);
            HandAnimator.SetBool("Running", false);
        }


    }

    private void LateUpdate()
    {
        dropAmmoPickUp();
    }

    IEnumerator Reload()

    {
        isReloading = true;
        Debug.Log("Reloading");
        Sound = GetComponent<AudioSource>();
        Sound.PlayOneShot(ReloadSound);

        for (int i = 0; i < 8; i++)

        {
            if (MaxAmmo > 0)
            {
                if (CurrentAmmo < 8)
                {
                    CurrentAmmo++;
                    MaxAmmo--;
                    animator.SetBool("Reloading", true);
                    HandAnimator.SetBool("Reloading", true);
                    yield return new WaitForSecondsRealtime(0.25f);
                }
            }
            else
            {
                Debug.Log("No Ammo!");
                animator.SetBool("Reloading", false);
                HandAnimator.SetBool("Reloading", false);
            }
                
        }

        animator.SetBool("Reloading", false);
        HandAnimator.SetBool("Reloading", false);

        isReloading = false;

        

    }

    void Fire()

    {
        
        CurrentAmmo--;

        Sound = GetComponent<AudioSource>();
        Sound.Play();

        MuzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fireCam.transform.position, fireCam.transform.forward, out hit, range))

        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            Boss bossTarget= hit.transform.GetComponent<Boss>();
            Head_Collider TargetHead= hit.transform.GetComponent<Head_Collider>();
            Head_Collider_Boss TargetBossHead= hit.transform.GetComponent<Head_Collider_Boss>();

            if (target !=null)
            {
                target.TakeDamage(dmg);
                score += 10;
            }
            if(TargetHead != null)
            {
                TargetHead.enemy.TakeDamage(5 * dmg);
                score += 30;
                Sound = GetComponent<AudioSource>();
                Sound.PlayOneShot(HeadShot);
            }
            if (bossTarget != null)
            {
                bossTarget.TakeDamage(dmg);
                score += 20;
            }
            if(TargetBossHead != null)
            {
                TargetBossHead.boss.TakeDamage(6 * dmg);
                score += 60;
                Sound = GetComponent<AudioSource>();
                Sound.PlayOneShot(HeadShot);
            }


            GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 0.5f);
        }

    }

    void dropAmmoPickUp()
    {
        if (GetComponentInParent<Movement>().isThereDropAmmo == true)
        {
            MaxAmmo += 8;
            GetComponentInParent<Movement>().isThereDropAmmo = false;
        }
    }
}
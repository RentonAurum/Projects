using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public float hp=0;
    public float hpmax=100;
    public float atk;
    public float def;

    public bool isdead = false;

    public Player_HUD HP_Bar;

    void Start()
    {
        isdead = false;
        atk = 10;
        def = 10;
        hp = hpmax;
        HP_Bar.SetMaxHP(hpmax);
    }

    void Update()
    {

    }

    public void takeDamage(float enemyAtk)
    {
        this.hp -=2*( enemyAtk - (int) (this.def / 2));

        HP_Bar.SetHP(hp);

        if (hp <= 0)
        {
            isdead = true;
        }
    }
}

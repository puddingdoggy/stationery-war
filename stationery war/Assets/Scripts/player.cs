using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum PlayerState
{
    Move,
    attack,
    Die,
    Pause
}



public class player : MonoBehaviour
{
    PlayerState playerState = PlayerState.Move;
    private Rigidbody2D rb;
    private Animator anim;

    public int PatkValue = 0;
    public float PmoveSpeed = 0;
    public float PatkDuration = 0;
    private float atkTimer = 0;
    private float numenemy = 0;

    public int PHP = 100;

    private enemy currentAtcEmy;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        numenemy = 0;
    }



    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Move:
                MoveUpdate();
                break;
            case PlayerState.attack:
                AttactUpdate();
                break;
            case PlayerState.Die:
                break;
            default:
                break;
        }

    }

    void MoveUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * PmoveSpeed * Time.deltaTime);
    }

    void AttactUpdate()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer > PatkDuration && currentAtcEmy != null)
        {
            currentAtcEmy.TakeDamage(PatkValue);
            atkTimer = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" || collision.tag == "enemyhouse")
        {
            //anim.SetBool("PIsAttacking", true);    //     ¶¯»­
            playerState = PlayerState.attack;
            currentAtcEmy = collision.GetComponent<enemy>();

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            currentAtcEmy = null;
            //anim.SetBool("PIsAttacking", false);
            playerState = PlayerState.Move;
        }
    }


    public void PTakeDamage(int pdamage)
    {
        this.PHP -= pdamage;
        if (PHP <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}

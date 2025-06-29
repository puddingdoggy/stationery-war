using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    Move,
    attack,
    Die,
    Pause
}



public class enemy : MonoBehaviour
{
    EnemyState enemyState = EnemyState.Move;
    private Rigidbody2D rb;
    private Animator anim;

    public int atkValue = 0;
    public float moveSpeed = 0;
    public float atkDuration = 0;
    private float atkTimer = 0;

    public int HP = 100;

    private float numplayer = 0;


    private player currentAtcPla;

    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        numplayer = 0;
    }

    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Move:
                MoveUpdate();
                break;
            case EnemyState.attack:
                AttactUpdate();
                break;
            case EnemyState.Die:
                break;
            default:
                break;
        }
    }

    void MoveUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);
    }

    void AttactUpdate()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer > atkDuration && currentAtcPla != null)
        {
            currentAtcPla.PTakeDamage(atkValue);
            atkTimer = 0;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Playerhouse")
        {
            anim.SetBool("IsAttacking", true);    //     ¶¯»­
            enemyState = EnemyState.attack;
            currentAtcPla = collision.GetComponent<player>();

        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("IsAttacking", false);
            currentAtcPla = null;
            enemyState = EnemyState.Move;
        }
    }


    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        if (HP <= 0)
        {
            Dead();
        }

    }


    private void Dead()
    {
        Destroy(gameObject);
    }

}

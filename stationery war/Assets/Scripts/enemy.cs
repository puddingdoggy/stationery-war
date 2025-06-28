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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Playerhouse")
        {
            //anim.SetBool("IsAttacking", true);    //     ¶¯»­
            enemyState = EnemyState.attack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //anim.SetBool("IsAttacking", false);
            enemyState = EnemyState.Move;
        }
    }

}

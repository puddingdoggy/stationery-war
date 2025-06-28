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
    private Rigidbody2D rb;
    public float moveSpeed = 2;
    private Animator anim;

    public int atkValue = 30;
    public float atkDuration = 2;
    private float atkTimer = 0;

    public int HP = 100;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }

    void MoveUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D RB;
    public BoxCollider2D BC;
    private float SpeedX;
    public float HorizontalSpeed;
    public float JumpForce;
    private bool isGrounded;
    public GameObject hitbox;
    public Transform HitPoint;
    public float HitRadius;
    public GameObject Punch;
    public SpriteRenderer SR;
    private float T;


    private void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
     }

    public void Update()
    {
        Attack();
        Down();
    }
    public void FixedUpdate()
    {
        Run();
        Jump();
    }

   private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Fight2D.Action(HitPoint.position, HitRadius, 10, 12, false);
            Punch.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Punch.SetActive(false);
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.D))
        {
            T = T+Time.deltaTime;
            SpeedX = -HorizontalSpeed;
            if (T > 1 ) SpeedX = SpeedX * 2;
        }
        else if (Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
            T = T + Time.deltaTime;
            SpeedX = HorizontalSpeed;
            if (T > 1) SpeedX = SpeedX * 2;
        }
        if (Input.GetKeyUp(KeyCode.A)| Input.GetKeyUp(KeyCode.D))
         {
             T = 0;
         }
        
        transform.Translate(SpeedX, 0, 0);
        SpeedX = 0;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            RB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void Down()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale=new Vector2(transform.localScale.x,1.5f);
            transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y - transform.localScale.y);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector2(transform.localScale.x, 3f);
            transform.position = new Vector2(transform.localPosition.x, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}

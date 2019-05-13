using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Controller : MonoBehaviour
{
    public Transform HitPoint;
    public float HitRadius;
    public GameObject punchsprite;
    private float DT,T,R;
    private Rigidbody2D RB;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

        Intelegenc(); 
        
    }
    private void Intelegenc()
    {
        DT += Time.deltaTime;
        if (DT > 5)
        {
            R = rand.Next(0, 101);
            Debug.Log(R);
            if (R < 30)
            {
                Jump();
            }
            else if (R > 30 && R < 60)
            {
                Down();
            }
            else if (R > 60)
            {
                Attack();
            }
            DT = 0;
        }
    }
    private void Attack()
    {
        //T += Time.deltaTime;
       // Debug.Log(T);
      //  if (T >= 1)
      //  {
            Fight2D.Action(HitPoint.position, HitRadius, 10, 12, false);
            punchsprite.SetActive(true);
            //  }
            //  else if (T > 0.5 && T < 1)
            //  {
      //      punchsprite.SetActive(false);
            //  }
    }
    private void Down()
    {
        transform.localScale = new Vector2(transform.localScale.x, 1.5f);
        transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y - transform.localScale.y);
        if (Time.deltaTime > 1)
        {
            transform.localScale = new Vector2(transform.localScale.x, 3f);
            transform.position = new Vector2(transform.localPosition.x, 0f);
        }
    }
    private void Jump()
    {
        RB.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
    }
}

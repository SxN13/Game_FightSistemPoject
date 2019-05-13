using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Hurtboxknee : MonoBehaviour
{
    public GameObject Enemy;

    //public bool hit;
    public float HP = 1;

    public void Start()
    {
    }
    public void Update()
    {
        if (HP <= 0)
        {
         Enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            HP = 1;
        }
   
    }
    /* public void OnTriggerEnter2D(Collider2D collision)
     {
         hit = true;
         lives = lives - 1;

     }
     public void OnTriggerExit2D(Collider2D collision)
     {
         hit = false;
     }*/

}

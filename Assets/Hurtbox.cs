using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Hurtbox : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject DeathSprite;
    public GameObject LiveSprite;
    //public bool hit;
    public float HP = 100;

    public void Start()
    {
        LiveSprite.SetActive(true);
        DeathSprite.SetActive(false);
    }
    public void Update()
    {
        if (HP <= 0)
        {
            Enemy.GetComponent<BoxCollider2D>().enabled=false;
            Enemy.GetComponent<Rigidbody2D>().gravityScale = 0f;
            LiveSprite.SetActive(false);
            DeathSprite.SetActive(true);
            Destroy(Enemy,10);
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

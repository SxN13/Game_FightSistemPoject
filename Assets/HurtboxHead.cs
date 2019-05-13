using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class HurtboxHead : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject DeathSprite;
    public GameObject LiveSprite;
    //public bool hit;
    public float HP = 1;

   
    public void Update()
    {
        if (HP <= 0)
        {
            Enemy.GetComponent<BoxCollider2D>().enabled = false;
            Enemy.GetComponent<Rigidbody2D>().gravityScale = 0f;
            LiveSprite.SetActive(false);
            DeathSprite.SetActive(true);
            Destroy(Enemy, 10);
        }
    }
}
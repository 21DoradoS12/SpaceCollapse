using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    private GameManager gameManager;
    private BoostTime boostTime;
    private MeteorHP meteorHP;
    private Rigidbody2D rigidbody;
    void Start()
    {
        meteorHP = GameObject.FindObjectOfType<MeteorHP>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0f, speed);
    }
    void Update()
    {
        rigidbody.velocity = new Vector2(0f, speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

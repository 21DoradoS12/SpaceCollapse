using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossLaser : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D collider2D;
    private GameManager gameManager;
    public float LaserTimeOn;
    public float LaserTimePause;
    public bool LaserOn;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<PolygonCollider2D>();
        LaserTimeOn = Random.Range(3f, 5f);
    }
    void Update()
    {
        if (LaserOn == true)
        {
            if (LaserTimeOn <= 0)
            {
                LaserTimePause = Random.Range(3f, 5f);
                LaserOn = false;
                spriteRenderer.enabled = false;
                collider2D.enabled = false;
            }
            LaserTimeOn -= Time.deltaTime;
            spriteRenderer.enabled = true;
            collider2D.enabled = true;
        }
        if (LaserOn == false)
        {
            if (LaserTimePause <= 0)
            {
                LaserTimeOn = Random.Range(4f, 6f);
                LaserOn = true;
                spriteRenderer.enabled = true;
                collider2D.enabled = true;
            }
            LaserTimePause -= Time.deltaTime;
            spriteRenderer.enabled = false;
            collider2D.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpaceShip")
        {

        }
        if (other.tag == "Bullet" || other.tag == "LeftRocket" || other.tag == "RightRocket")
        {
            Destroy(other.gameObject);
        }
    }
}

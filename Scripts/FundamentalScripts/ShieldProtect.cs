using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldProtect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D collider2D;
    private BoostTime boostTime;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<CircleCollider2D>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
    }
    void Update()
    {
        if (boostTime.ActivateShield == true)
        {
            spriteRenderer.enabled = true;
            collider2D.enabled = true;
        }
        if (boostTime.ActivateShield == false)
        {
            spriteRenderer.enabled = false;
            collider2D.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meteor" || other.tag == "TinyMeteor" || other.tag == "Asteroid" || other.tag == "FlyingSaucer" || other.tag == "ShootingSaucer" || other.tag == "BigSaucer")
        {
            gameManager.AddScoreShield();
            Destroy(other.gameObject);
        }
    }
}

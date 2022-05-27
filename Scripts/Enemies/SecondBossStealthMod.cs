using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossStealthMod : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    public float StealthTimeOn;
    public float StealthTimePause;
    public bool StealthOn;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StealthTimeOn = Random.Range(7f, 10f);
        StealthOn = true;
    }
    void Update()
    {
        if (StealthOn == true)
        {
            if (StealthTimeOn <= 0)
            {
                StealthTimePause = Random.Range(2f, 4f);
                StealthOn = false;
                spriteRenderer.enabled = true;
            }
            StealthTimeOn -= Time.deltaTime;
            spriteRenderer.enabled = false;
        }
        if (StealthOn == false)
        {
            if (StealthTimePause <= 0)
            {
                StealthTimeOn = Random.Range(3f, 5f);
                StealthOn = true;
                spriteRenderer.enabled = false;
            }
            StealthTimePause -= Time.deltaTime;
            spriteRenderer.enabled = true;
        }
    }
}

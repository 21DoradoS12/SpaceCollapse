using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public GameManager gameManager;
    private int score;
    private SpriteRenderer SpriteRenderer;
    public bool sp7 = false;
    public bool sp6 = false;
    public bool sp5 = false;
    public bool sp4 = false;
    public bool sp3 = false;
    public bool sp2 = false;
    public bool sp1 = false;
    public bool sp0 = false;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        score = gameManager.PlayerScore;
        ChangeBG();
    }
    void ChangeBG()
    {
        if (score < 50)
        {
            sp7 = false;
            SpriteRenderer.sprite = sprite8;
        }
        if (score >= 50)
        {
            sp7 = true;
            sp6 = false;
            SpriteRenderer.sprite = sprite7;
        }
        if (score >= 100)
        {
            sp6 = true;
            sp5 = false;
            SpriteRenderer.sprite = sprite6;
        }
        if (score >= 150)
        {
            sp5 = true;
            sp4 = false;
            SpriteRenderer.sprite = sprite5;
        }
        if (score >= 200)
        {
            sp4 = true;
            sp3 = false;
            SpriteRenderer.sprite = sprite4;
        }
        if (score >= 250)
        {
            sp3 = true;
            sp2 = false;
            SpriteRenderer.sprite = sprite3;
        }
        if (score >= 300)
        {
            sp2 = true;
            sp1 = false;
            SpriteRenderer.sprite = sprite2;
        }
        if (score >= 350)
        {
            sp1 = true;
            sp0 = false;
            SpriteRenderer.sprite = sprite1;
        }
        if (score >= 500)
        {
            sp0 = true;
            SpriteRenderer.sprite = sprite0;
        }
    }
}

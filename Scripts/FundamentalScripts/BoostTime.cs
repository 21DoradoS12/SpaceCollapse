using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoostTime : MonoBehaviour
{
    public float timeStartShield = 10f;
    public float timeStartFastShoot = 10f;
    public float timeStartStar = 10f;
    public float timeStartTripleShoot = 10f;
    public float timeStartMegaShoot = 10f;
    public Text ShieldTimeText;
    public Text FastShootTimeText;
    public Text StarTimeText;
    public Text TripleShootText;
    public Text MegaShootText;
    public Image HP1;
    public Image HP2;
    public Image HP3;
    public Image HP4;
    public Image HP5;
    private GameManager gameManager;
    public bool ActivateShield = false;
    public bool ActivateFastShooting = false;
    public bool ActivateStar = false;
    public bool ActivateTripleShoot = false;
    public bool ActivateMegaShoot = false;
    private ShipControl shipControl;
    public GameObject BulletPrefab;
    public Slider slider;
    public Sprite normalBullet;
    public Sprite fastBullet;
    void Start()
    {
        BulletPrefab.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0);
        BulletPrefab.GetComponent<SpriteRenderer>().sprite = normalBullet;
        shipControl = GameObject.FindObjectOfType<ShipControl>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ShieldTimeText.text = timeStartShield.ToString();
        FastShootTimeText.text = timeStartFastShoot.ToString();
        StarTimeText.text = timeStartStar.ToString();
        TripleShootText.text = timeStartTripleShoot.ToString();
        MegaShootText.text = timeStartMegaShoot.ToString();
    }
    void Update()
    {
        HPCheck();
        slider.value = shipControl.HP;
        if (ActivateShield == true || timeStartShield <= 0)
        {
            ShieldTimeText.enabled = true;
            timeStartShield -= Time.deltaTime;
            ShieldTimeText.text = Mathf.Round(timeStartShield).ToString();
            if (timeStartShield <= 0)
            {
                ActivateShield = false;
                ShieldTimeText.enabled = false;
                timeStartShield = 10f;
                ShieldTimeText.text = timeStartShield.ToString();
            }
        }
        if (ActivateFastShooting == true ||  timeStartFastShoot <= 0)
        {
            FastShootTimeText.enabled = true;
            timeStartFastShoot -= Time.deltaTime;
            FastShootTimeText.text = Mathf.Round(timeStartFastShoot).ToString();
            BulletPrefab.GetComponent<SpriteRenderer>().sprite = fastBullet;
            shipControl.ReloadTime = 0.25f;
            if (timeStartFastShoot <= 0)
            {
                ActivateFastShooting = false;
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = normalBullet;
                shipControl.ReloadTime = 0.5f;
                FastShootTimeText.enabled = false;
                timeStartFastShoot = 10f;
                ShieldTimeText.text = timeStartShield.ToString();
            }
        }
        if (ActivateStar == true || timeStartStar <= 0)
        {
            StarTimeText.enabled = true;
            timeStartStar -= Time.deltaTime;
            StarTimeText.text = Mathf.Round(timeStartStar).ToString();
            if (timeStartStar <= 0)
            {
                ActivateStar = false;
                StarTimeText.enabled = false;
                timeStartStar = 10f;
                StarTimeText.text = timeStartStar.ToString();
            }
        }
        if (ActivateTripleShoot == true || timeStartTripleShoot <= 0)
        {
            TripleShootText.enabled = true;
            timeStartTripleShoot -= Time.deltaTime;
            TripleShootText.text = Mathf.Round(timeStartTripleShoot).ToString();
            if (timeStartTripleShoot <= 0)
            {
                ActivateTripleShoot = false;
                TripleShootText.enabled = false;
                timeStartTripleShoot = 10f;
                TripleShootText.text = timeStartTripleShoot.ToString();
            }
        }
        if (ActivateMegaShoot == true || timeStartMegaShoot <= 0)
        {
            MegaShootText.enabled = true;
            timeStartMegaShoot -= Time.deltaTime;
            MegaShootText.text = Mathf.Round(timeStartMegaShoot).ToString();
            BulletPrefab.GetComponent<Transform>().localScale = new Vector3 (1f,1f,0);
            if (timeStartMegaShoot <= 0)
            {
                ActivateMegaShoot = false;
                MegaShootText.enabled = false;
                BulletPrefab.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0);
                timeStartMegaShoot = 10f;
                MegaShootText.text = timeStartMegaShoot.ToString();
            }
        }
    }
    public void HPCheck()
    {
        if (shipControl.HP == 0)
        {
            HP1.enabled = false;
            HP2.enabled = false;
            HP3.enabled = false;
            HP4.enabled = false;
            HP5.enabled = false;
        }
        if (shipControl.HP == 1)
        {
            HP1.enabled = true;
            HP2.enabled = false;
            HP3.enabled = false;
            HP4.enabled = false;
            HP5.enabled = false;
        }
        if (shipControl.HP == 2)
        {
            HP1.enabled = true;
            HP2.enabled = true;
            HP3.enabled = false;
            HP4.enabled = false;
            HP5.enabled = false;
        }
        if (shipControl.HP == 3)
        {
            HP1.enabled = true;
            HP2.enabled = true;
            HP3.enabled = true;
            HP4.enabled = false;
            HP5.enabled = false;
        }
        if (shipControl.HP == 4)
        {
            HP1.enabled = true;
            HP2.enabled = true;
            HP3.enabled = true;
            HP4.enabled = true;
            HP5.enabled = false;
        }
        if (shipControl.HP == 5)
        {
            HP1.enabled = true;
            HP2.enabled = true;
            HP3.enabled = true;
            HP4.enabled = true;
            HP5.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject BulletPrefab;
    public float speed = 10f;
    public float xLimitRight = 2.9f;
    public float xLimitLeft = -2.9f;
    public float ReloadTime = 0.5f;
    public int HP = 3;
    private SpriteRenderer spriteRenderer;
    private float elapsedTime = 0f;
    private BoostTime boostTime;
    private RocketBoost rocketBoost;
    public AudioSource ShootAudioSource;
    public AudioSource CrashRocket;
    public AudioSource PickBonus;
    private ThirdBossLaser thirdBossLaser;
    public Vector3 shipPosition;
    private RightMove rightMove;
    private LeftMove leftMove;
    void Start()
    {
        rocketBoost = GameObject.FindObjectOfType<RocketBoost>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        rightMove = GameObject.FindObjectOfType<RightMove>();
        leftMove = GameObject.FindObjectOfType<LeftMove>();
    }

    void Update()
    {
        if (rocketBoost.RightRocket == true)
        {
            xLimitRight = 2.285f;
        }
        if (rocketBoost.RightRocket == false)
        {
            xLimitRight = 2.9f;
        }
        if (rocketBoost.LeftRocket == true)
        {
            xLimitLeft = -2.285f;
        }
        if (rocketBoost.LeftRocket == false)
        {
            xLimitLeft = -2.9f;
        }
        if (gameManager.GameOverText.enabled == true)
            Destroy(this.gameObject);
        shipPosition = this.gameObject.transform.position;
        thirdBossLaser = GameObject.FindObjectOfType<ThirdBossLaser>();
        elapsedTime += Time.deltaTime;

        if (rightMove.RightS == true)
            transform.Translate(rightMove.RightSide * speed * Time.deltaTime, 0f, 0f);
        if (leftMove.LeftS == true)
            transform.Translate(leftMove.LeftSide * speed * Time.deltaTime, 0f, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, xLimitLeft, xLimitRight);
        transform.position = position;

        if (elapsedTime > ReloadTime && boostTime.ActivateTripleShoot == false)
        {
            ShootAudioSource.Play();
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, 1.2f, 0f);
            Instantiate(BulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f;
        }
        if (elapsedTime > ReloadTime && boostTime.ActivateTripleShoot == true)
        {
            ShootAudioSource.Play();
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, 1.2f, 0f);
            Instantiate(BulletPrefab, spawnPos, Quaternion.identity);
            spawnPos += new Vector3(0.5f, 0f, 0f);
            Instantiate(BulletPrefab, spawnPos, Quaternion.identity);
            spawnPos += new Vector3(-1f, 0f, 0f);
            Instantiate(BulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f;
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FirstBoss" || other.tag == "ThirdBoss" || other.tag == "SecondBoss")
        {
            HP = 0;
            gameManager.PlayerDied();
            Destroy(gameObject);
        }
        if (other.tag == "Meteor" || other.tag == "TinyMeteor" || other.tag == "Asteroid" || other.tag == "FlyingSaucer" || other.tag == "ShootingSaucer" || other.tag == "BigSaucer")
        {
            gameManager.AddScoreCrash();
            HP -= 1;
            if (HP == 0)
            {
                gameManager.PlayerDied();
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "ThirdBossLaser")
        {
            CrashRocket.Play();
            HP -= 1;
            thirdBossLaser.LaserOn = false;
            thirdBossLaser.LaserTimeOn = 0;
            thirdBossLaser.LaserTimePause = Random.Range(3f, 5f);
            if (HP == 0)
            {
                gameManager.PlayerDied();
                Destroy(gameObject);
            }
        }
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            HP -= 1;
            if (HP == 0)
            {
                gameManager.PlayerDied();
                Destroy(gameObject);
            }
        }
        if (other.tag == "Heart")
        {
            if (HP < 5)
            { 
                HP += 1;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "BoostShield")
        {
            boostTime.ActivateShield = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "ShootingBoost")
        {
            boostTime.ActivateFastShooting = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "StarBoost")
        {
            boostTime.ActivateStar = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "TrippleShot")
        {
            boostTime.ActivateTripleShoot = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "RocketBoost")
        {
            if (rocketBoost.RightRocket == true && rocketBoost.LeftRocket == false)
            {
                rocketBoost.LeftRocket = true;
                Destroy(other.gameObject);
            }
            if (rocketBoost.RightRocket == false)
            {
                rocketBoost.RightRocket = true;
                Destroy(other.gameObject);
            }
            else
                Destroy(other.gameObject);
        }
        if (other.tag == "MegaShoot")
        {
            boostTime.ActivateMegaShoot = true;
            Destroy(other.gameObject);
        }
    }
}

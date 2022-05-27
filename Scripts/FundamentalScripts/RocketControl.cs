using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private BoostTime boostTime;
    public int HP = 1;
    private float elapsedTime = 0f;
    public float speed = 10f;
    public float xLimitLeft = -2.9f;
    public float xLimitRight = 2f;
    public float ReloadTime = 0.5f;
    public GameObject BulletPrefab;
    private RocketBoost rocketBoost;
    private BossHealth bossHealth;
    private ThirdBossLaser thirdBossLaser;
    private ShipControl ship;
    private RightMove rightMove;
    private LeftMove leftMove;
    void Start()
    {
        ship = GameObject.FindObjectOfType<ShipControl>();
        thirdBossLaser = GameObject.FindObjectOfType<ThirdBossLaser>();
        rocketBoost = GameObject.FindObjectOfType<RocketBoost>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        bossHealth = GameObject.FindObjectOfType<BossHealth>();
        rightMove = GameObject.FindObjectOfType<RightMove>();
        leftMove = GameObject.FindObjectOfType<LeftMove>();
    }
    void Update()
    {
        if (ship.HP == 0)
            Destroy(this.gameObject);
        elapsedTime += Time.deltaTime;

        if (rightMove.RightS == true)
            transform.Translate(rightMove.RightSide * speed * Time.deltaTime, 0f, 0f);
        if (leftMove.LeftS == true)
            transform.Translate(leftMove.LeftSide * speed * Time.deltaTime, 0f, 0f);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, xLimitLeft, xLimitRight);
        transform.position = position;

        if (elapsedTime > ReloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, 1.2f, 0f);
            Instantiate(BulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meteor" || other.tag == "TinyMeteor" || other.tag == "Asteroid" || other.tag == "FlyingSaucer" || other.tag == "ShootingSaucer" || other.tag == "BigSaucer")
        {
            HP -= 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
            rocketBoost.LeftRocket = false;
            rocketBoost.j = 0;
        }
        if (other.tag == "FirstBoss" || other.tag == "ThirdBoss" || other.tag == "SecondBoss")
        {
            HP -= 1;
            bossHealth.BossHP -= 10;
            Destroy(gameObject);
            rocketBoost.LeftRocket = false;
            rocketBoost.j = 0;
        }
        if (other.tag == "ThirdBossLaser")
        {
            HP -= 1;
            thirdBossLaser.LaserOn = false;
            thirdBossLaser.LaserTimeOn = 0;
            thirdBossLaser.LaserTimePause = Random.Range(3f, 5f);
            rocketBoost.LeftRocket = false;
            Destroy(this.gameObject);
        }
    }
}

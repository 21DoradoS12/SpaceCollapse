using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    public int BossHP;
    public Slider slider;
    private BoostTime boostTime;
    private GameManager gameManager;
    private BossSpawn bossSpawn;
    public Vector3 pos;
    void Start()
    {
        bossSpawn = GameObject.FindObjectOfType<BossSpawn>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameObject.tag == "FirstBoss")
            BossHP = 50;
        if (gameObject.tag == "ThirdBoss")
            BossHP = 75;
        if (gameObject.tag == "SecondBoss")
            BossHP = 60;
    }
    void Update()
    {
        pos = gameObject.transform.position;
        slider.value = BossHP;
        if (BossHP <= 0 && boostTime.ActivateStar == false)
        {
            if (bossSpawn.f1 == 1)
            {
                bossSpawn.f1 = 0;
                Destroy(gameObject);
                gameManager.BossAddScore();
            }
            if (bossSpawn.f3 == 1)
            {
                bossSpawn.f3 = 0;
                Destroy(gameObject);
                gameManager.ThirdBossAddScore();
            }
            if (bossSpawn.f2 == 1)
            {
                bossSpawn.f2 = 0;
                Destroy(gameObject);
                gameManager.SecondBossAddScore();
            }
        }
        if (BossHP <= 0 && boostTime.ActivateStar == true)
        {
            if (bossSpawn.f1 == 1)
            {
                bossSpawn.f1 = 0;
                Destroy(gameObject);
                gameManager.BoostBossAddScore();
            }
            if (bossSpawn.f3 == 1)
            {
                bossSpawn.f3 = 0;
                Destroy(gameObject);
                gameManager.BoostThirdBossAddScore();
            }
            if (bossSpawn.f2 == 1)
            {
                bossSpawn.f2 = 0;
                Destroy(gameObject);
                gameManager.BoostSecondBossAddScore();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && boostTime.ActivateMegaShoot == false)
        {
            BossHP -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet" && boostTime.ActivateMegaShoot == true)
        {
            BossHP -= 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}

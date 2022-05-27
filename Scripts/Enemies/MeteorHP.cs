using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHP : MonoBehaviour
{
    private GameManager gameManager;
    private BoostTime boostTime;
    public GameObject shieldPrefab;
    public GameObject heartPrefab;
    public GameObject starPrefab;
    public int HP;
    public AudioSource DestroyMeteor;
    public AudioSource HitMeteor;
    public int item;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        this.HP = 3;
        this.item = Random.Range(0, 21);
    }
    void Update()
    {
        if (this.HP <= 0 && boostTime.ActivateStar == false)
        {
            if (item == 1)
            {
                Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2 || item == 3)
            {
                Instantiate(starPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 4)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            DestroyMeteor.Play();
            Destroy(gameObject);
            gameManager.AddScoreMeteor();
        }
        if (this.HP <= 0 && boostTime.ActivateStar == true)
        {
            if (item == 1)
            {
                Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2 || item == 3)
            {
                Instantiate(starPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 4)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            DestroyMeteor.Play();
            Destroy(gameObject);
            gameManager.BoostAddScoreMeteor();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && boostTime.ActivateMegaShoot == false)
        {
            HP -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet" && boostTime.ActivateMegaShoot == true)
        {
            HP -= 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}

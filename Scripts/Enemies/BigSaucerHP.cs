using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSaucerHP : MonoBehaviour
{
    private GameManager gameManager;
    private BoostTime boostTime;
    public int HP;
    public GameObject heartPrefab;
    public GameObject shieldPrefab;
    public GameObject rocketPrefab;
    public int item;
    private AudioSource audioSource;
    public GameObject FlyingSaucer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        this.HP = 10;
        this.item = Random.Range(0, 21);
    }
    void Update()
    {
        Vector3 position = transform.position;
        if (this.HP <= 0 && boostTime.ActivateStar == false)
        {
            if (item == 1)
            {
                Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(rocketPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            transform.position = position;
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(-0.5f, -0.5f, 0f);
            Instantiate(FlyingSaucer, spawnPos, Quaternion.identity);
            spawnPos += new Vector3(1f, 0f, 0f);
            Instantiate(FlyingSaucer, spawnPos, Quaternion.identity);
            Destroy(gameObject);
            gameManager.AddScoreBigSaucer();
        }
        if (this.HP <= 0 && boostTime.ActivateStar == true)
        {
            if (item == 1)
            {
                Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(rocketPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            transform.position = position;
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(-0.5f, -0.5f, 0f);
            Instantiate(FlyingSaucer, spawnPos, Quaternion.identity);
            spawnPos += new Vector3(1f, 0f, 0f);
            Instantiate(FlyingSaucer, spawnPos, Quaternion.identity);
            Destroy(gameObject);
            gameManager.BoostAddScoreBigSaucer();
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

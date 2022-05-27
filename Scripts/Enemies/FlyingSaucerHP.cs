using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucerHP : MonoBehaviour
{
    private GameManager gameManager;
    private BoostTime boostTime;
    public int HP;
    public GameObject starPrefab;
    public GameObject tripleSootPrefab;
    public GameObject shieldPrefab;
    public int item;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        this.HP = 4;
        this.item = Random.Range(0, 21);
    }
    void Update()
    {
        if (this.HP <= 0 && boostTime.ActivateStar == false)
        {
            if (item == 1)
            {
                Instantiate(starPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2)
            {
                Instantiate(tripleSootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gameManager.AddScoreFlyingSaurce();
        }
        if (this.HP <= 0 && boostTime.ActivateStar == true)
        {
            if (item == 1)
            {
                Instantiate(starPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2)
            {
                Instantiate(tripleSootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(shieldPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gameManager.BoostAddScoreFlyingSaurce();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyMeteorHP : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject heartPrefab;
    public GameObject megaShootPrefab;
    public GameObject fastShootPrefab;
    public int item;
    private BoostTime boostTime;
    public int HP;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
        this.HP = 2;
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
            if (item == 2)
            {
                Instantiate(megaShootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(fastShootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gameManager.AddScoreTinyMeteor();
        }
        if (this.HP <= 0 && boostTime.ActivateStar == true)
        {
            if (item == 1)
            {
                Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 2)
            {
                Instantiate(megaShootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            if (item == 3)
            {
                Instantiate(fastShootPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gameManager.BoostAddScoreTinyMeteor();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public GameObject TinyMeteorPrefab;
    public GameObject AsteroidPrefab;
    public GameObject FlyingSaucerPrefab;
    public GameObject ShootingSaucerPrefab;
    public GameObject BigSaucerPrefab;
    public float SpawnXLimit = 2.9f;
    private float ConstantSpawnDelayMeteor = 2.1f;
    private float ConstantSpawnDelayTinyMeteor = 9f;
    private float ConstantSpawnDelayAsteroid = 15f;
    private float ConstantSpawnDelayFlyingSaucer = 4f;
    private float ConstantSpawnDelayShootingSaucer = 8f;
    private float ConstantSpawnDelayBigSaucer = 15f;
    public GameManager gameManager;
    private BossSpawn bossSpawn;
    private int score;
    void Start()
    {
        bossSpawn = GameObject.FindObjectOfType<BossSpawn>();

        SpawnMeteor();
        SpawnTinyMeteor();
        SpawnAsteroid();
        SpawnFlyingSaucer();
        SpawnShootingSaucer();
        SpawnBigSaucer();
    }
    void SpawnMeteor()
    {
        if ((score >= 200 && score < 500) || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1)
        {
            Invoke("SpawnMeteor", ConstantSpawnDelayMeteor);
        }
        if (score <= 200 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(MeteorPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnMeteor", ConstantSpawnDelayMeteor);
        }
        if (score > 500)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(MeteorPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnMeteor", ConstantSpawnDelayMeteor);
        }
    }
    void SpawnTinyMeteor()
    {
        if (score >= 50 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0 && score < 200)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(TinyMeteorPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnTinyMeteor", ConstantSpawnDelayTinyMeteor);
        }
        if (score < 50 || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1 || (score <= 500 && score > 200))
        {
            Invoke("SpawnTinyMeteor", ConstantSpawnDelayTinyMeteor);
        }
        if (score > 500)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(TinyMeteorPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnTinyMeteor", ConstantSpawnDelayTinyMeteor);
        }
    }
    void SpawnAsteroid()
    {
        if (score >= 100 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0 && score < 200)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(AsteroidPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnAsteroid", ConstantSpawnDelayAsteroid);
        }
        if (score < 100 || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1 || (score <= 500 && score > 200))
        {
            Invoke("SpawnAsteroid", ConstantSpawnDelayAsteroid);
        }
        if (score > 500)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(AsteroidPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnAsteroid", ConstantSpawnDelayAsteroid);
        }
    }
    void SpawnFlyingSaucer()
    {
        if (score < 200 || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1)
        {
            Invoke("SpawnFlyingSaucer", ConstantSpawnDelayFlyingSaucer);
        }
        if (score >= 200 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(FlyingSaucerPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnFlyingSaucer", ConstantSpawnDelayFlyingSaucer);
        }
    }
    void SpawnShootingSaucer()
    {
        if (score < 250 || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1)
        {
            Invoke("SpawnShootingSaucer", ConstantSpawnDelayShootingSaucer);
        }
        if (score >= 250 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(ShootingSaucerPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnShootingSaucer", ConstantSpawnDelayShootingSaucer);
        }
    }
    void SpawnBigSaucer()
    {
        if (score < 300 || bossSpawn.f1 == 1 || bossSpawn.f3 == 1 || bossSpawn.f2 == 1)
        {
            Invoke("SpawnBigSaucer", ConstantSpawnDelayBigSaucer);
        }
        if (score >= 300 && bossSpawn.f1 == 0 && bossSpawn.f3 == 0 && bossSpawn.f2 == 0)
        {
            ChangeMeteorSpawnSpeedMeteor();
            float random = Random.Range(-SpawnXLimit, SpawnXLimit);
            Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
            Instantiate(BigSaucerPrefab, spawnPos, Quaternion.identity);
            Invoke("SpawnBigSaucer", ConstantSpawnDelayBigSaucer);
        }
    }
    void Update()
    {
        score = gameManager.PlayerScore;
    }
    void ChangeMeteorSpawnSpeedMeteor()
    {
        if (score < 50)
        {
            ConstantSpawnDelayMeteor = 2.1f;
            ConstantSpawnDelayTinyMeteor = 9.6f;
        }
        if (score >= 100)
        {
            ConstantSpawnDelayMeteor = 2f;
            ConstantSpawnDelayTinyMeteor = 9.2f;
            ConstantSpawnDelayAsteroid = 14f;
        }
        if (score >= 150)
        {
            ConstantSpawnDelayMeteor = 1.9f;
            ConstantSpawnDelayTinyMeteor = 8.4f;
            ConstantSpawnDelayAsteroid = 13.5f;
        }
        if (score >= 200)
        {
            ConstantSpawnDelayFlyingSaucer = 3.5f;
            ConstantSpawnDelayShootingSaucer = 7.2f;
            ConstantSpawnDelayBigSaucer = 14.5f;
        }
        if (score >= 250)
        {
            ConstantSpawnDelayFlyingSaucer = 3f;
            ConstantSpawnDelayShootingSaucer = 6.3f;
            ConstantSpawnDelayBigSaucer = 13.5f;
        }
        if (score >= 300)
        {
            ConstantSpawnDelayFlyingSaucer = 2.5f;
            ConstantSpawnDelayShootingSaucer = 5.7f;
            ConstantSpawnDelayBigSaucer = 12.5f;
        }
        if (score >= 350)
        {
            ConstantSpawnDelayMeteor = 1.5f;
            ConstantSpawnDelayTinyMeteor = 7.5f;
            ConstantSpawnDelayAsteroid = 12f;
            ConstantSpawnDelayFlyingSaucer = 2f;
            ConstantSpawnDelayShootingSaucer = 5f;
            ConstantSpawnDelayBigSaucer = 11f;
        }
    }
}

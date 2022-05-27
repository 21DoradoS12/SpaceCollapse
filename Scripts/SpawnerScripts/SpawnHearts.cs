using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHearts : MonoBehaviour
{
    public GameObject HeartPrefab;
    private float SpawnXLimit = 6f;
    private float ConstantSpawnDelay;
    private int timer = 0;
    public GameManager gameManager;
    private float score;
    void Start()
    {
        if (timer == 0)
        {
            Invoke("Spawn", 30f);
            timer = 1;
        }
    }
    void Update()
    {
        score = gameManager.PlayerScore;
    }
    void Spawn()
    {
        ConstantSpawnDelay = Random.Range(20f, 50f);
        float random = Random.Range(-SpawnXLimit, SpawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(HeartPrefab, spawnPos, Quaternion.identity);
        Invoke("Spawn", ConstantSpawnDelay);
    }
}

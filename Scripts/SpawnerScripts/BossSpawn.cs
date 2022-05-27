using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject FirstBossPrefab;
    public GameObject ThirdBossPrefab;
    public GameObject SecondBossPrefab;
    public GameManager gameManager;
    private int score;
    public bool FirstBoss = false;
    public bool ThirdBoss = false;
    public bool SecondBoss = false;
    public int f1 = 0;
    public int f3 = 0;
    public int f2 = 0;
    void Start()
    {
    }
    void Update()
    {
        score = gameManager.PlayerScore;
        SpawnBoss();
    }
    private void SpawnBoss()
    {
        if (score > 100 && FirstBoss == false)
        {
            f1 = 1;
            FirstBoss = true;
            Vector3 spawnPos = transform.position;
            Instantiate(FirstBossPrefab, spawnPos, Quaternion.identity);
        }
        if (score > 400 && ThirdBoss == false)
        {
            f3 = 1;
            ThirdBoss = true;
            Vector3 spawnPos = transform.position;
            Instantiate(ThirdBossPrefab, spawnPos, Quaternion.identity);
        }
        if (score > 250 && SecondBoss == false)
        {
            f2 = 1;
            SecondBoss = true;
            Vector3 spawnPos = transform.position;
            Instantiate(SecondBossPrefab, spawnPos, Quaternion.identity);
        }
    }
}

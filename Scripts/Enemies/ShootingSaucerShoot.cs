using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSaucerShoot : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    public float speed = -10f;
    public float ReloadTime = 0.5f;
    private float elapsedTime = 0f;
    public float xLimit = 3.5f;
    void Start()
    {
        
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        if (elapsedTime > ReloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, -1.2f, 0f);
            Instantiate(EnemyBulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f;
        }
    }
}

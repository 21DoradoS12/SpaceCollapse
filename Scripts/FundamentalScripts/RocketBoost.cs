using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBoost : MonoBehaviour
{
    public GameObject RocketPrefabRight;
    public GameObject RocketPrefabLeft;
    private Vector3 spawnPos;
    public bool RightRocket = false;
    public bool LeftRocket = false;
    public float i = 0;
    public float j = 0;
    void Start()
    {

    }
    void Update()
    {
        spawnPos = transform.position;
        if (RightRocket == true && i == 0)
        {
            spawnPos = spawnPos + new Vector3(0.7f, 0, 0);
            Instantiate(RocketPrefabRight, spawnPos, Quaternion.identity);
            i = 1;
        }
        else if (LeftRocket == true && j == 0)
        {
            spawnPos = spawnPos + new Vector3(-0.7f, 0, 0);
            Instantiate(RocketPrefabLeft, spawnPos, Quaternion.identity);
            j = 1;
        }
    }
}

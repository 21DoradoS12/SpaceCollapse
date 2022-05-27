using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSaucerMover : MonoBehaviour
{
    private float speeddown = -0.3f;
    public float XLimit = 3f;
    private Rigidbody2D rigidbody;
    public float speedside = 0f;
    public bool right = false;
    public bool left = false;
    public int i = 2;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speeddown);
        this.i = Random.Range(0, 2);
        if (i == 1)
            right = true;
        if (i == 0)
            left = true;
        if (i != 1 && i != 0)
            right = true;
    }
    void Update()
    {
        if (right == true)
        {
            speedside = 7f;
            if (XLimit <= gameObject.transform.position.x)
            {
                right = false;
                left = true;
            }
        }
        if (left == true)
        {
            speedside = -7f;
            if (-XLimit >= gameObject.transform.position.x)
            {
                left = false;
                right = true;
            }
        }
        rigidbody.velocity = new Vector2(speedside, speeddown);
    }
}

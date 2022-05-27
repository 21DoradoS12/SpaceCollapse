using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSaucerMover : MonoBehaviour
{
    public float speed = -0.7f;

    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speed);

    }
    void Update()
    {

    }
}

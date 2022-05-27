using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoosts : MonoBehaviour
{
    private float speed = -3f;
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speed);
    }
    void Update()
    {
        rigidbody.velocity = new Vector2(0, speed);
    }
}

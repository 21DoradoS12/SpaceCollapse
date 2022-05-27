using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyMeteorMover : MonoBehaviour
{
    public float speed = -3.5f;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    private float speed = -6.5f;
    public float lowerYvalue = -15f;
    public float upperYvalue = 30f;
    private ChangeBackGround ChangeBackGround;

    void Start()
    {
        ChangeBackGround = GameObject.FindObjectOfType<ChangeBackGround>();

    }

    void Update()
    {
        ChangeSpeedBG();
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        if (transform.position.y <= lowerYvalue)
        {
            transform.Translate(0f, upperYvalue, 0f);
        }
    }
    public void ChangeSpeedBG()
    {
        if (ChangeBackGround.sp7 == true)
        {
            speed = -7f;
        }
        if (ChangeBackGround.sp6 == true)
        {
            speed = -7.5f;
        }
        if (ChangeBackGround.sp5 == true)
        {
            speed = -8f;
        }
        if (ChangeBackGround.sp4 == true)
        {
            speed = -8.5f;
        }
        if (ChangeBackGround.sp3 == true)
        {
            speed = -9f;
        }
        if (ChangeBackGround.sp2 == true)
        {
            speed = -9.5f;
        }
        if (ChangeBackGround.sp1 == true)
        {
            speed = -10f;
        }
    }
}

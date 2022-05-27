using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    private ShipControl shipControl;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float timeDeath;
    void Start()
    {
        animator.enabled = false;
        spriteRenderer.enabled = false;
        shipControl = GameObject.FindObjectOfType<ShipControl>();
    }
    void Update()
    {
        this.gameObject.transform.position = shipControl.shipPosition;
        if (shipControl.HP == 0)
        {
            spriteRenderer.enabled = true;
            animator.enabled = true;
        }
    }
}

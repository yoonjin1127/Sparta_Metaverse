using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator animator;
    SpriteRenderer spr;

    Rigidbody2D rb;

    float h;
    float v;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2 (h, v) * speed;

        if(h < 0)
        {
            spr.flipX = true;
            animator.SetBool("IsMove", true);
        }
        else if(h > 0)
        {
            spr.flipX = false;
            animator.SetBool("IsMove", true);
        }
        else if(v != 0)
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

    }
}

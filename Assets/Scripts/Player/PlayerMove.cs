using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [Header("Move inf")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float multiplier;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private bool FacingRight = true;
    [SerializeField] private Transform playerFoot;
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
       
    }
    private void simpleMove()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed  , rb.velocity.y,0);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity=new Vector2(rb.velocity.x,JumpForce*multiplier);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
    private void Update()
    {
        simpleMove();
        Jump();
        CheckFlipA();
        CheckFlipB();
    }
    void Flip()
    {
        FacingRight=!FacingRight;
        transform.Rotate(0, 180, 0);
    }
    void CheckFlipA()
    {
        if (Input.GetKeyDown(KeyCode.A)&&FacingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.D)&& !FacingRight)
        {
            Flip();
        }
    }
    void CheckFlipB()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && FacingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !FacingRight)
        {
            Flip();
        }
    }
}

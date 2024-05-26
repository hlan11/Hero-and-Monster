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
    bool isOnGround;
    bool isJumping;
    private void Start()
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
        isOnGround = false;
        isJumping = true;
        if(Input.GetKeyDown(KeyCode.W))
        rb.AddForce(new Vector2(0, 2) * JumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("-------Player On Ground-------");
            isOnGround = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("==========Player Jumping==========");
            isJumping = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("_________isOnGround = false_______________");
            isOnGround = false;
        }
    }
    private void Update()
    {
        Jump();
        simpleMove();
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

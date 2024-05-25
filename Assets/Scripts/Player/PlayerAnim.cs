using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject playerFoot;
    bool isGrounded = true;
    bool isJumping;
    [Header("Player Sound")]
    [SerializeField] private AudioSource attackSound;
    [Header("Player Ghost Trail")]
    [SerializeField] private GameObject GhostTrailPlayer;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D playerFoot)
    {
        if (playerFoot.collider.CompareTag("Ground")) 
        {
            
            isGrounded = true;
        }
        else
        {
            
            isGrounded= false;
        }
    }
    private void Update()
    {
        CheckAnimation();
    }
    void CheckAnimation()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Block");
        }
        bool isAttacking = Input.GetMouseButtonDown(0);
        anim.SetBool("isAttacking", isAttacking);
        //attackSound.Play();
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("isScrolling");
        }
        bool isJumping = rb.velocity.y > 0;
        anim.SetBool("isJumping", isJumping);
    }
}

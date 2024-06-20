using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private GameObject playerFoot;
    [Header("Player Sound")]
    [SerializeField] private AudioSource attackSound;
    [Header("Player Ghost Trail")]
    [SerializeField] private GameObject GhostTrailPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if(Input.GetMouseButtonDown(0))
        {
        attackSound.Play();
        Debug.Log("Attack Sound Play");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("isScrolling");
        }
        bool isJumping = rb.velocity.y > 0;
        anim.SetBool("isJumping", isJumping);
    }
}

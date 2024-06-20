using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.ComponentModel;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] private float enemyDamage;
    [SerializeField] protected float moveSpeed;
    [Header("Player Attack")]
    public LayerMask playerLayer;
    [SerializeField] protected Transform playerAttackRange;
    [SerializeField] protected float playerAttackRadius;

    [Header("Enemy Move")]
    [SerializeField] protected float flipRight;
    [SerializeField] protected float flipLeft;
    [SerializeField] protected float timeMove;
    protected bool isFacingRight = true;
    [Header("Enemy Health")]
    [SerializeField] protected Slider healthBar;
    public int maxHealth { get; set; }
    public int currentHealth { get;set; }
    [SerializeField] protected Color colorCircle;
    [Header("Spawn Coin")]
    [SerializeField] protected GameObject coin;
    [SerializeField] protected Transform coinSpawn;
    [Header("FlashFX")]
    public OnHitFX _onhitFX;
    //[SerializeField] private ParticleSystem deathVFX;
    protected virtual void Start()
    {
        _onhitFX = GetComponent<OnHitFX>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        maxHealth = currentHealth;
        //deathVFX = GetComponent<ParticleSystem>();
    }
    protected virtual void Update()
    {
        healthBar.value = currentHealth;
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = colorCircle;
        Gizmos.DrawWireSphere(playerAttackRange.position, playerAttackRadius);
    }
    protected virtual Collider2D CheckPlayer()
    {
        return Physics2D.OverlapCircle(playerAttackRange.position, playerAttackRadius, playerLayer);
    }
    protected virtual void AutoMove()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FlipPointB"))
        {
            if (isFacingRight)
            {
                Flip();
                autoMoveA();
            }
            else
            {
                autoMoveA();
            }
        }
        if (collision.CompareTag("FlipPointA"))
        {
            if (!isFacingRight)
            {
                Flip();
                autoMoveB();
            }
            else
            {
                autoMoveB();
            }
        }
    }
    protected virtual void autoMoveA()
    {
        transform.DOMoveX(flipLeft, timeMove);
    }
    protected virtual void autoMoveB()
    {
        transform.DOMoveX(flipRight, timeMove);
    }

    protected virtual void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    public abstract void TakeDamage(int damage);
}

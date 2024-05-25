using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] private float enemyDamage;
    [Header("Player Attack")]
    public LayerMask playerLayer;
    [SerializeField] protected Transform playerAttackRange;
    [SerializeField] protected float playerAttackRadius;
    [SerializeField] protected float flipRight;
    [SerializeField] protected float flipLeft;
    [SerializeField] protected float timeMove;
    protected bool isFacingRight=true;
    [Header("Health")]
    [SerializeField]protected float moveSpeed;
    [SerializeField] protected Slider healthBar;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected Color colorCircle;
    [Header("Spawn Coin")]
    [SerializeField] protected GameObject coin;
    [SerializeField] protected Transform coinSpawn;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar.value = currentHealth;
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = colorCircle;
        Gizmos.DrawWireSphere(playerAttackRange.position, playerAttackRadius);
    }
    protected virtual Collider2D CheckPlayer()
    {
        return Physics2D.OverlapCircle(playerAttackRange.position, playerAttackRadius,playerLayer);
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
    protected virtual void Died()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(coin,transform.position,transform.rotation);
        }
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= (int)enemyDamage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Died();
            //Instantiate(coin, transform.position, transform.rotation);
        }
    }
}

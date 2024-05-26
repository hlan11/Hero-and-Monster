using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private int maxHealth=100;
    private float currentHealth;
    [SerializeField] private int maxMana=100;
    private float currentMana;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider manaBar;
    [SerializeField] private int attackDamage;
    [SerializeField] private float timeDestroy;
    [Header("Attack Range")]
    public LayerMask enemyLayer;
    [SerializeField] private Transform enemyAttackRange;
    [SerializeField] private float enemyAttackRadius;
    public Collider2D myEnemy;
    [SerializeField] private float swordDamage;
    [Header("Mouse Controller")]
    [SerializeField] private float clickTime = 0f;
    private float lastClickThreshHold = 1.2f;
   // [SerializeField] private Animator anim;
    public OnHitFX _onHitFX;
    public PlayerAnim _anim;
    private void Start()
    {
        _anim=GetComponent<PlayerAnim>();
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
    private void UpdateHealthAndMana()
    {
        healthBar.value = currentHealth;
        manaBar.value = currentMana;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            _anim.anim.SetTrigger("getHurt");
            _onHitFX.StartCoroutine("FlashFX");
            currentHealth -= 10;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            _anim.anim.SetTrigger("getHurt");
            _onHitFX.StartCoroutine("FlashFX");
            Debug.Log("-------------------touch bullet-------------------");
            currentHealth -= 5;
        }
    }
    void UseMana()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentMana -= 5;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackRange.position, enemyAttackRadius, enemyLayer);
        foreach(Collider2D myEnemy in hitEnemies)
        {
            myEnemy.GetComponent<EnemyController>().TakeDamage(2);
            Debug.Log("hit "+ myEnemy.name);
        }
    }
    private void DealDamageToEnemy(Collider2D enemy, int enemyDamage)
    {
        enemy.GetComponent<EnemyController>().TakeDamage(enemyDamage);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyAttackRange.position, enemyAttackRadius);
    }
    //public Collider2D CheckEnemy()
    //{
    //    return Physics2D.OverlapCircle(enemyAttackRange.position, enemyAttackRadius,enemyLayer);
    //}
   
    private void Update()
    {
        UpdateHealthAndMana();
        Died();
        Attack();
        UseMana();
    }
    void Died()
    {
        if (currentHealth <= 0)
        {
            _anim.anim.SetTrigger("Die");
            Invoke("destroyPlayer", timeDestroy);
        }
    }
    void destroyPlayer()
    {
        Destroy(gameObject);
    }
}

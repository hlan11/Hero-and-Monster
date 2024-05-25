using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Animator anim;
    
    void Awake()
    {
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
            currentHealth -= 10;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("-------------------touch bullet-------------------");
            currentHealth -= 5;
        }
    }
    void Attack()
    {
        var enemy = CheckEnemy();
        if (CheckEnemy())
        {
            Debug.Log("Hit enemy , - "+attackDamage);
            DealDamageToEnemy(enemy, attackDamage);
            //enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
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
    public Collider2D CheckEnemy()
    {
        return Physics2D.OverlapCircle(enemyAttackRange.position, enemyAttackRadius,enemyLayer);
    }
   
    private void Update()
    {
        UpdateHealthAndMana();
        Died();
        Attack();
    }
    void Died()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            Invoke("destroyPlayer", timeDestroy);
        }
    }
    void destroyPlayer()
    {
        Destroy(gameObject);
    }
}

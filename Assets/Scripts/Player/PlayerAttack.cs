using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private int maxHealth=100;
    public float currentHealth { get; set; }
    [SerializeField] private int maxMana=100;
    public float currentMana { get; set; }
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider manaBar;
    public int attackDamage { get; set; }    
    [SerializeField] private float timeDestroy;
    [Header("Attack Range")]
    public LayerMask enemyLayer;
    [SerializeField] private Transform enemyAttackRange;
    [SerializeField] private float enemyAttackRadius;
    public Collider2D myEnemy;
    [Header("Mouse Controller")]
    [SerializeField] private float clickTime = 0f;
    private float lastClickThreshHold = 1.2f;
   // [SerializeField] private Animator anim;
    public OnHitFX _onHitFX;
    public PlayerAnim _anim;
    [SerializeField] private ParticleSystem playerDeath;
    [Header("Panel Lose Game")]
    [SerializeField] private GameObject panelLoseGame;
    [SerializeField] private float timeSetPanel;
    private EnemyController _enemyController;
    private void Start()
    {
        _anim=GetComponent<PlayerAnim>();
        currentHealth = maxHealth;
        currentMana = maxMana;
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
    void CheckMana()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentMana -= 5;
        }
    }
    private void UpdateManaAndHealth()
    {
        manaBar.value = currentMana;
        healthBar.value = currentHealth;
    }
    
    void Attack()
    {
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackRange.position, enemyAttackRadius, enemyLayer);
        var enemy = CheckEnemy();
        if ((bool)enemy)
        {
            if(Input.GetMouseButton(0))
            _enemyController.currentHealth -= 10;
        }
    }
    private void DealDamageToEnemy(Collider2D enemy, int damage)
    {
        enemy.GetComponent<EnemyController>().TakeDamage(10);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyAttackRange.position, enemyAttackRadius);
    }
    public Collider2D CheckEnemy()
    {
        return Physics2D.OverlapCircle(enemyAttackRange.position, enemyAttackRadius, enemyLayer);
    }

    private void Update()
    {
        UpdateManaAndHealth();
        Died();
        Attack();
        
    }
    void Died()
    {
        if (currentHealth <= 0)
        {
            _anim.anim.SetTrigger("Die");
            Invoke("destroyPlayer", 0.5f);
        }
    }
    void SetLosePanel()
    {
        Time.timeScale = 0;
        panelLoseGame.SetActive(true);
    }
    void destroyPlayer()
    {
        Instantiate(playerDeath,transform.position,Quaternion.identity);
        Destroy(gameObject);
        Invoke("SetLosePanel", timeSetPanel);
    }
}

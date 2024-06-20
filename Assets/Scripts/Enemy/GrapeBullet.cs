using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem hitPlayer;
    [SerializeField]private BulletDamage bulletSetting;
    [SerializeField] private float duration;

    
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hitPlayer.Play();
            Destroy(gameObject);
        }
    }
    public void Shoot(Vector2 force  ,int damage)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        bulletSetting.SetBulletDamage(-damage);
    }
    private void OnEnable()
    {
        Invoke(nameof(SelfDestroy), duration);
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}

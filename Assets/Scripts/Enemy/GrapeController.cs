using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrapeController : EnemyController
{
    [SerializeField] private GrapeBullet grapeBullet;
    [SerializeField] private int damage;
    [SerializeField] private float speedBullet;
    [SerializeField] private float rateOfSpawn;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Collider2D player;
    private float _rate = 0;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (CheckPlayer())
        {
            rb.velocity = Vector2.zero;
            player = CheckPlayer();
            anim.SetBool("isAttacking",true);
            Shoot(player);
        }
    }
    private void Shoot(Collider2D player)
    {
        _rate -= Time.deltaTime;
        if (_rate > 0)
        {
            return;
        }
        var playerPosition = player.transform.position;
        var diffX = playerPosition.x - transform.position.x;
        var bulletForceX = (diffX > 0f ? 1f : -1f) * speedBullet;
        var bulletForce = new Vector2(bulletForceX, 0f);
        var bullet = Instantiate(grapeBullet, bulletSpawn.position, Quaternion.identity);
        grapeBullet.Shoot(bulletForce, damage);
        _rate = rateOfSpawn;
    }
    public abstract override void TakeDamage(int damage);
}

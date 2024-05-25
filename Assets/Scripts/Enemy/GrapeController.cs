using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeController : EnemyController
{
    [SerializeField] private GrapeBullet grapeBullet;
    [SerializeField] private int damage;
    [SerializeField] private float speedBullet;
    [SerializeField] private float rateOfSpawn;
    [SerializeField] private Transform bulletSpawn;
    private float _rate = 0;
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        bool isAttacking = CheckPlayer();
        if (CheckPlayer())
        {
            anim.SetBool("isAttacking",true);
            Shoot(CheckPlayer());
        }
        else
        {
            anim.SetBool("isAttacking", false);
            rb.velocity = new Vector2(moveSpeed, 0);
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
}

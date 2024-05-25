using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    public int GetDamage()
    {
        return damage;
    }
    public int SetBulletDamage(int damage)
    {
        return this.damage = damage;
    }
}

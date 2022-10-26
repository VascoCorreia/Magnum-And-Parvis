using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectiles/FireProjectile")]
public class FireProjectile : ProjectileData
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;
    private List<int> burnTickTimers = new List<int>();
    private int ticks =  5;

    public override void Initialize(Transform obj)
    {
        shootScript = obj.gameObject.GetComponent<Shooting>();
        shootScript.gunDamage = damage;
        shootScript.bulletSpeed = speed;
    }
}

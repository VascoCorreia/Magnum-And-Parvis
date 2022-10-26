using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Projectiles/LightningProjectile")]
public class LightningProjectile : ProjectileData
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;

    public override void Initialize(Transform obj)
    {
        shootScript = obj.gameObject.GetComponent<Shooting>();
        shootScript.gunDamage = damage;
        shootScript.bulletSpeed = speed;
    }
}

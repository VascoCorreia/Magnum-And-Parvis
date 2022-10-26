using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileData : ScriptableObject
{
    [SerializeField]
    public Color color;

    public float maxbulletLifeTime = 2;

    public Shooting shootScript;

    public abstract void Initialize(Transform obj);

    public void collided(GameObject enemy, int damage)
    {
        if (enemy.CompareTag("Enemy"))
        {
            var health = enemy.GetComponent<HealthScript>();
            health.TakeDamage(damage, enemy);
        }

    }

}

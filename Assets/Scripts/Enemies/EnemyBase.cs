using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public EnemyData enemyData;

    private int damage;
    private float health;

    void Start()
    {
        damage = enemyData.damage;
        health = enemyData.health;
        GetComponent<NavMeshAgent>().speed = enemyData.speed;
    }
}

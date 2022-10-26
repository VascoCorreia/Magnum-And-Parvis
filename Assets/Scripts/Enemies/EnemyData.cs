using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    //General
    public int damage;
    public float speed, health;
    public Color color;

    //Ranged Enemy
    public float coolDownShootTime = 1;
    public float bulletSpeed = 100;
    public float shootTimer = 0;

}

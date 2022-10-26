using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public EnemyData enemyData;

    [SerializeField]
    private float currentHealth;


    private void OnEnable()
    {

        currentHealth = enemyData.health;

    }


    public void TakeDamage(float damageAmount, GameObject obj)
    {
        if (obj!=null)
        {
            StartCoroutine(damageColorChange(obj));
            currentHealth -= damageAmount;


            if (currentHealth <= 0)
            {
                Die(obj);
            }
        }
    }

    private void Die(GameObject obj)
    {
        Destroy(obj);
    }

    IEnumerator damageColorChange(GameObject obj)
    {
        //Color normalColor = obj.GetComponent<MeshRenderer>().material.color;
        obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.15f);
        obj.GetComponent<MeshRenderer>().material.SetColor("_Color", enemyData.color);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private PlayerData playerData;

    private float currentHealth;

    public HPBar healthBar;

    public GameMaster gm;

    private bool isInvincible;


    private void OnEnable()
    {
        isInvincible = false;
        currentHealth = playerData.health;
        healthBar.SetMaxHealth(playerData.health);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }


    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return;
        currentHealth -= damageAmount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {


            GameMaster.KillPlayer(this);


        }

        StartCoroutine(BecomeTemporarilyInvincible());


    }

    public void RecieveHealth(float healthAmount, GameObject obj)
    {
        if (obj != null)
        {
            currentHealth += healthAmount;
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(playerData.invicibilityFrames);
        isInvincible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {

            TakeDamage(-1);
        }


        if (currentHealth > playerData.health)
        {

            currentHealth = playerData.health;
        }

        healthBar.SetHealth(currentHealth);

    }
}

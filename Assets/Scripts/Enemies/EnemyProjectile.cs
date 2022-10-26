using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float bulletLifeTime = 0;
    public float maxbulletLifeTime = 10;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bulletLifeTime += Time.deltaTime;

        if (bulletLifeTime >= maxbulletLifeTime)
        {

            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.CompareTag("Player"))
        {
            var health = hit.collider.GetComponent<PlayerScript>();
            if (health != null)
            {
                Debug.Log("Player HIt");
                health.TakeDamage(1);
            }
        }

        Destroy(gameObject);
    }

}

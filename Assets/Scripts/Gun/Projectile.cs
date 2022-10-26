using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData[] projectileData;
    public Shooting shootingScript;
    public ElementEffects elementEffects;
    public PuzzleBlock puzzle;


    public float bulletLifeTime = 0;
    private void Start()
    {
        shootingScript = GameObject.Find("Gun").GetComponent<Shooting>();
        elementEffects = GameObject.Find("Gun").GetComponent<ElementEffects>();
        puzzle = gameObject.GetComponent<PuzzleBlock>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bulletLifeTime += Time.deltaTime;

        if (bulletLifeTime >= projectileData[shootingScript.selectedElement].maxbulletLifeTime)
        {

            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision hit)
    {
        projectileData[shootingScript.selectedElement].collided(hit.gameObject, shootingScript.gunDamage);
        elementEffects.ApplyElement(hit.gameObject);
        Destroy(gameObject);

    }
}

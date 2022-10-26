using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{

    public int correctElement;
    private int playerElement;
    [SerializeField]
    private GameObject gun;

    private void Start()
    {
        gun = GameObject.Find("Gun");
        
    }

    void Update()
    {
        playerElement = gun.GetComponent<Shooting>().selectedElement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyBlock();
        }
    }

    public void DestroyBlock()
    {
        if (playerElement == correctElement)

        {
            Destroy(gameObject);
        }
    }
}

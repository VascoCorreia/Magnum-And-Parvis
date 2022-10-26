using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerNormalScale;

    private void Start()
    {
        playerNormalScale = player.transform.localScale;
    }

    private void Update()
    {
        player.transform.localScale = playerNormalScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.transform.SetParent(transform.parent);
            
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.transform.SetParent(null);
            //other.transform.localScale = playerNormalScale;
        }

    }
}

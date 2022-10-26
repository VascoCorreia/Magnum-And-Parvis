using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTriggers : MonoBehaviour
{
    public GameObject[] message;
    public float messageTimer;
    private int index;

    void Start()
    {
        index = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Magnum")
        {
            index = 0;

            StartCoroutine("NextMessage");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Magnum")
        {
            StopCoroutine("NextMessage");
            index = 0;

            foreach (GameObject message in message)
            {
                message.SetActive(false);
            }
        }
    }

    IEnumerator NextMessage()
    {

        while (index != message.Length)
        {
            message[index].SetActive(true);
            yield return new WaitForSeconds(messageTimer);
            if (index != message.Length)
            {
                index++;
                message[index - 1].SetActive(false);
            }
        }
    }
}

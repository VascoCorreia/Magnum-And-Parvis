using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject[] doorSwitches;
    public GameObject[] enemies;

    void Update()
    {
        int enemiesAliveCount = 0;
        int switchesAliveCount = 0;

        for (var i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemiesAliveCount++;
            }
        }

        for (var i = 0; i < doorSwitches.Length; i++)
        {
            if (doorSwitches[i] != null)
            {
                switchesAliveCount++;
            }
        }

        if (switchesAliveCount == 0 && enemiesAliveCount == 0)
        {
            OpenDoor(gameObject);
        }

    }


    public void OpenDoor(GameObject door)
    {

        door.SetActive(false);

    }

    public void CloseDoor(GameObject door)
    {

        door.SetActive(true);
    }


}

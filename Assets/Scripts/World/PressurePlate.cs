using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject door;
    private DoorScript doorScript;

    private void Start()
    {
        doorScript = door.GetComponent<DoorScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door opened");
        doorScript.OpenDoor(door);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Door closed");
    //    doorScript.CloseDoor(door);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    public Shooting shooting;

    public GameObject crosshair;


    private void Awake()
    {
        //shooting = GetComponent<Shooting>();
    }


    // Update is called once per frames
    void Update()
    {

        

        //Debug.Log(selectedElement);


        if (shooting.selectedElement == 0)
        {

            crosshair.GetComponent<Image>().color = new Color32(255, 144, 47, 255);


        }
        if (shooting.selectedElement == 1)
        {

            crosshair.GetComponent<Image>().color = new Color32(134, 255, 223, 255);


        }
        if (shooting.selectedElement == 2)
        {

            crosshair.GetComponent<Image>().color = new Color32(255, 253, 0, 255);


        }
        if (shooting.selectedElement == 3)
        {

            crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);


        }


    }
}

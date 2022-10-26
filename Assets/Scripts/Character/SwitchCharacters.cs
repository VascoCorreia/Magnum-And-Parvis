using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCharacters : MonoBehaviour
{
    public GameObject Parvis;
    public GameObject Magnum;
    public GameObject gun;
    public GameObject cantSwitchMessage;

    public float switchRadius;

    private MonoBehaviour[] magnumComponents;
    private MonoBehaviour[] parvisComponents;

    [SerializeField]
    private PlayerData playerData;

    private bool parvisGoingToMagnumAnimation = false;

    [SerializeField]
    private CinemachineFreeLook magnumCamera;

    [SerializeField]
    private CinemachineFreeLook parvisCamera;




    void Start()
    {
        magnumComponents = Magnum.GetComponents<MonoBehaviour>();
        parvisComponents = Parvis.GetComponents<MonoBehaviour>();

        playerData.currentCharacter = "Magnum";
    }

    void Update()
    {
        SwitchCharacter();
        ParvisGoingToShoulder();
    }

    private void SwitchCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && playerData.currentCharacter == "Magnum")
        {
            ToParvis();
        }

        else if (Input.GetKeyDown(KeyCode.Tab) && playerData.currentCharacter == "Parvis")
        {
            ToMagnum();
        }
    }

    private void ToMagnum()
    {
        bool isInRadius = false;

        Collider[] colliders = Physics.OverlapSphere(Magnum.transform.position, switchRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].name == "Parvis")
                isInRadius = true;
            else
                isInRadius = false;
        }

        if (isInRadius)
        {
            foreach (MonoBehaviour c in magnumComponents)
            {
                c.enabled = true; //enable magnum scipts
            }

            foreach (MonoBehaviour c in parvisComponents)
            {
                c.enabled = false; //disable all scripts except CharacterController
            }

            parvisCamera.Priority = 0; // change cameras
            magnumCamera.Priority = 1;
            Parvis.transform.parent = Magnum.transform; // reparent
            parvisGoingToMagnumAnimation = true;
            Parvis.GetComponent<CharacterController>().enabled = false; //needs to be deactiavted separately
            gun.GetComponent<Shooting>().enabled = true;
            playerData.currentCharacter = "Magnum";
        }
        else
        {
            StartCoroutine("SwitchMessage");
        }
    }

    private void ToParvis()
    {
        foreach (MonoBehaviour c in magnumComponents)
        {
            c.enabled = false; //disable all scripts except CharacterController
        }

        foreach (MonoBehaviour c in parvisComponents)
        {
            c.enabled = true; //enable parvis scipts
        }

        parvisCamera.Priority = 1; // change cameras
        magnumCamera.Priority = 0;
        Parvis.transform.parent = null; //remove from parent
        Parvis.GetComponent<CharacterController>().enabled = true; //needs to be actiavted separately
        gun.GetComponent<Shooting>().enabled = false;
        playerData.currentCharacter = "Parvis";
    }

    private void ParvisGoingToShoulder()
    {
        if (parvisGoingToMagnumAnimation && Parvis.transform.localPosition != new Vector3(-0.7f, 0, 0))
            Parvis.transform.localPosition = Vector3.Lerp(Parvis.transform.localPosition, new Vector3(-0.7f, 0, 0), 7 * Time.deltaTime);
        else
            parvisGoingToMagnumAnimation = false;
    }

    IEnumerator SwitchMessage()
    {
        cantSwitchMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        cantSwitchMessage.SetActive(false);
    }
}

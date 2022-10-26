using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElementEffects : MonoBehaviour
{

    private int playerElement;

    [HideInInspector]
    public List<int> burnTickTimers = new List<int>();
    [HideInInspector]
    public List<int> slowTickTimers = new List<int>();

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerElement = GetComponent<Shooting>().selectedElement;
    }

    public void ApplyElement(GameObject objecthit)
    {
        if (objecthit.CompareTag("Enemy"))
        {
            if (playerElement == 0)
            {

                ApplyBurn(5, objecthit);


            }
            if (playerElement == 1)
            {

                ApplySlow(5, objecthit);


            }
            if (playerElement == 2)
            {


                ApplyLightning(objecthit);


            }
            if (playerElement == 3)
            {
                ApplyKnockback(objecthit);
                //apply knockback to enemy


            }

        }

    }

    void ApplyBurn(int ticks, GameObject obj)
    {
        {

            if (burnTickTimers.Count <= 0)
            {

                burnTickTimers.Add(ticks);
                StartCoroutine(Burn(obj));
                //  Debug.Log("Burning");

            }
            else
            {
                burnTickTimers.Add(ticks);

            }

        }

    }

    void ApplySlow(int ticks, GameObject obj)
    {
        {

            if (slowTickTimers.Count <= 0)
            {

                slowTickTimers.Add(ticks);
                StartCoroutine(Slow(obj));
                //Debug.Log("Slowed");

            }
            else
            {
                slowTickTimers.Add(ticks);

            }
        }

    }

    void ApplyLightning(GameObject obj)
    {
        Collider[] colliders = Physics.OverlapSphere(obj.transform.position, 10f);
        foreach (Collider c in colliders)
        {

            if (c.GetComponent<HealthScript>())
            {

                c.GetComponent<HealthScript>().TakeDamage(1, c.gameObject);

            }
        }
    }

    public void ApplyKnockback(GameObject obj)
    {
        NavMeshAgent agent = obj.GetComponent<NavMeshAgent>();

        agent.velocity = -obj.transform.forward * 16;
    }

    IEnumerator Burn(GameObject obj)
    {
        while (burnTickTimers.Count > 0)
        {

            for (int i = 0; i < burnTickTimers.Count; i++)
            {

                burnTickTimers[i]--;
                if (obj != null)
                    obj.GetComponent<HealthScript>().TakeDamage(1, obj);

            }
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }

    IEnumerator Slow(GameObject obj)
    {
        while (slowTickTimers.Count > 0)
        {

            for (int i = 0; i < slowTickTimers.Count; i++)
            {

                slowTickTimers[i]--;
                if (obj != null)
                    obj.GetComponent<NavMeshAgent>().speed = 7;

            }
            slowTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
            if (obj != null)
                obj.GetComponent<NavMeshAgent>().speed = 10;
        }
    }
}

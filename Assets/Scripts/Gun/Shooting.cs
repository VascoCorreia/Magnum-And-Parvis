using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float coolDownShootTime;
    private float shootTimer = 0;

    public Transform gun;
    public ProjectileData[] projectiles;
    public GameObject bulletPrefab;

    public Camera cam;

    /*[HideInInspector]*/
    public int gunDamage;
    /*[HideInInspector]*/
    public float bulletSpeed;

    //elements : 0 fire , 1 ice, 2 lightning, 3 air

    public int selectedElement;

    private void Start()
    {
        projectiles[selectedElement].Initialize(gun);
    }

    void Update()
    {

        shootTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            Shoot();

        SelectElement();
    }

    private void Shoot()
    {
        if (shootTimer >= coolDownShootTime)
        {
            shootTimer = 0;

            Ray cameraRay = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

            RaycastHit hit;

            Vector3 targetPoint;
            Debug.DrawRay(cameraRay.origin, cameraRay.direction * 1000, Color.red, 5);

            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, 9) && !Physics.Linecast(cam.transform.position, gun.position, 9))
            {
                targetPoint = hit.point;
            }

            else
                targetPoint = cameraRay.GetPoint(1000);

            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            bullet.GetComponent<MeshRenderer>().material.SetColor("_Color", projectiles[selectedElement].color);

            if (Input.GetKey("left shift"))
                bullet.GetComponent<Rigidbody>().velocity = (targetPoint - gun.transform.position).normalized * bulletSpeed;
            else
                bullet.GetComponent<Rigidbody>().velocity = -transform.forward * bulletSpeed;
        }
    }

    private void SelectElement()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedElement >= 3)
                selectedElement = 0;
            else
                selectedElement++;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedElement <= 0)
                selectedElement = 3;
            else
                selectedElement--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            selectedElement = 0;
            projectiles[selectedElement].Initialize(gun);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            selectedElement = 1;
            projectiles[selectedElement].Initialize(gun);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            selectedElement = 2;
            projectiles[selectedElement].Initialize(gun);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            selectedElement = 3;
            projectiles[selectedElement].Initialize(gun);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject vfxFirePoint, vfxHitPoint;
    void Update()
    {
        Shooting();
    }// Update

    void Shooting()
    {
        Debug.DrawRay(firePoint.position, transform.forward * 100f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, transform.forward, out hit, 100f))
        {
            Debug.DrawRay(firePoint.position, transform.forward * 100f, Color.red);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(vfxFirePoint, firePoint.position, Quaternion.identity);
                Instantiate(vfxHitPoint, hit.point, Quaternion.identity);

                if (hit.collider.name == "Enemy")
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(1);
                    }
                }//hit

                if (hit.collider.name == "meteorite")
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(0, 10, 0);
                    hit.collider.GetComponent<Rigidbody>().AddTorque(0, 50, 0);
                }//OBS
            }//KeyCode.Space

        }//Physics.Raycast

    }//Shooting
}//Shooter

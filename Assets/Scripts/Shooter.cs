using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject vfxFirePoint, vfxHitPoint;
    public int damage = 5; // กำหนดดาเมจของกระสุน

    void Update()
    {
        Shooting();
    }// Update

    void Shooting()
    {
        Debug.DrawRay(firePoint.position, transform.forward * 50f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, transform.forward, out hit, 50f))
        {
            Debug.DrawRay(firePoint.position, transform.forward * 50f, Color.red);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(vfxFirePoint, firePoint.position, Quaternion.identity);
                Instantiate(vfxHitPoint, hit.point, Quaternion.identity);

                if (hit.collider.CompareTag("Meteorite"))
                {
                    Meteorite enemy = hit.collider.GetComponent<Meteorite>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }

                if (hit.collider.CompareTag("Meteorite"))
                {
                    Meteorite meteor = hit.collider.GetComponent<Meteorite>();
                    if (meteor != null)
                    {
                        meteor.TakeDamage(damage); // ยิงหินแล้วเลือดลด
                    }
                }
            }
        }
    }
}

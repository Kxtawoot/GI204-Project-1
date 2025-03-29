using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject vfxHitPoint;
    public int damage = 5;
    public float maxRange = 50f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * maxRange, Color.green, 0.2f);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxRange))
        {
            Debug.DrawRay(firePoint.position, firePoint.forward * maxRange, Color.red, 0.2f);

            Instantiate(vfxHitPoint, hit.point, Quaternion.identity);

            Meteorite meteor = hit.collider.GetComponent<Meteorite>();
            if (meteor != null)
            {
                meteor.TakeDamage(damage);
            }
        }
    }
}

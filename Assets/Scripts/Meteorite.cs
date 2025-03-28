using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public int health = 10;
    public GameObject explosionEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public int health = 10;
    public float speed = 3f;
    public GameObject explosionEffect;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(player);
        }    
        
    }

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

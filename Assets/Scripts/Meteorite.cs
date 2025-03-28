using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public int health = 10; // เลือดของหิน

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // ทำลายหินเมื่อเลือดหมด
        }
    }
}

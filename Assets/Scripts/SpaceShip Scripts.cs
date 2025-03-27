using UnityEngine;

public class SpaceShipScripts : MonoBehaviour
{
    private Rigidbody rb;
    public float engineThrust = 50f;
    public float liftForce = 30f;
    public float drag = 0.03f;
    public float angularDrag = 0.03f;
    public float strafeThrust = 30f;
    public float verticalThrust = 30f;

    public int damageTaken = 10; //ดาเมจที่ได้รับ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * engineThrust;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward * engineThrust;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right * strafeThrust;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right * strafeThrust;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movement += transform.up * verticalThrust;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            movement -= transform.up * verticalThrust;
        }

        rb.AddForce(movement);

        rb.velocity *= (1 - drag);
        rb.angularVelocity *= (1 - angularDrag);
<<<<<<< HEAD
    }
<<<<<<< HEAD

    void PitchControl()
    {
        // Control for pitch (up and down)
        if (Input.GetKey(KeyCode.Q)) // Q for pitch up
        {
            transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)) // E for pitch down
        {
            transform.Rotate(Vector3.left * pitchSpeed * Time.deltaTime);
        }
=======
>>>>>>> parent of b2f747e (แก้ไขให้หมุนกล้องหลังชนกับวัคถุในฉาก)
    }


<<<<<<< HEAD
}

    public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // ค่าตั้งต้น HP
    private int currentHealth;

    public string gameOverSceneName = "GameOver";  // ชื่อของซีน Game Over

    void Start()
    {
        currentHealth = maxHealth;  // กำหนดค่าผู้เล่นเริ่มต้นที่เต็ม
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageTaken);
            }

            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        // ลด HP ของ Player
        currentHealth -= damage;
        Debug.Log("Player HP: " + currentHealth);

        // ถ้า HP ของ Player หมด
        if (currentHealth <= 0)
        {
            currentHealth = 0;  // ตั้งค่า HP ไม่ให้เป็นค่าติดลบ
            Die(); // ทำให้ Player ตาย
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // คุณสามารถทำสิ่งต่างๆ ในนี้ เช่น Game Over หรือหยุดเกม
        Time.timeScale = 0;  // หยุดเวลา
        Debug.Log("Game Over!");  // ปรากฏใน Console
    }

    // ฟังก์ชันสำหรับการรีเซ็ต HP เมื่อเริ่มใหม่
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
=======






=======
>>>>>>> parent of d74e474 (ใช้ Q เงยหน้า E กดหน้าลง)
>>>>>>> 4463a00195f3e4a7ecd8bfe9dc1c2cdd43938283
}

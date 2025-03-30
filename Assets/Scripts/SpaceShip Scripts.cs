using UnityEngine;

public class SpaceShipScripts : MonoBehaviour
{
    private Rigidbody rb;
    public float engineThrust = 50f;
    public float liftForce = 30f;
    public float drag = 0f;
    public float angularDrag = 0f;
    public float strafeThrust = 30f;
    public float verticalThrust = 30f;
    public float rotationSpeed = 50f;
    public float pitchSpeed = 25f;
    public int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += transform.forward * engineThrust;
        if (Input.GetKey(KeyCode.S)) movement -= transform.forward * engineThrust;
        if (Input.GetKey(KeyCode.A)) movement -= transform.right * strafeThrust;
        if (Input.GetKey(KeyCode.D)) movement += transform.right * strafeThrust;
        if (Input.GetKey(KeyCode.Space)) movement += transform.up * verticalThrust;

        rb.AddForce(movement);
        rb.velocity *= (1 - drag);
        rb.angularVelocity *= (1 - angularDrag);

        RotationControl();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRotation();
        }
    }

    void RotationControl()
    {
        float pitch = 0f;
        float yaw = 0f;

        if (Input.GetKey(KeyCode.LeftShift)) pitch = pitchSpeed;
        if (Input.GetKey(KeyCode.LeftControl)) pitch = -pitchSpeed;
        if (Input.GetKey(KeyCode.Q)) yaw = -rotationSpeed;
        if (Input.GetKey(KeyCode.E)) yaw = rotationSpeed;

        rb.AddTorque(transform.right * pitch * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddTorque(transform.up * yaw * Time.deltaTime, ForceMode.VelocityChange);
    }

    void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // รีเซ็ตการหมุนรอบแกน Y
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); // ตั้งให้หน้าหันไปทางแกน Z
        rb.angularVelocity = Vector3.zero; // รีเซ็ตความเร็วในการหมุน
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

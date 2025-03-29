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
    public float rotationSpeed = 100f; // ความเร็วในการหมุน
    public float pitchSpeed = 100f; // ความเร็วในการเงยหน้าหรือกดหน้าลง
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
        if (Input.GetKey(KeyCode.LeftControl)) movement -= transform.up * verticalThrust;

        rb.AddForce(movement);
        rb.linearVelocity *= (1 - drag);
        rb.angularVelocity *= (1 - angularDrag);

        PitchControl();

        if (Input.GetMouseButton(1)) // คลิกขวาค้างไว้
        {
            RotateTowardsMouse();
        }
    }

    void PitchControl()
    {
        float pitch = 0f;
        if (Input.GetKey(KeyCode.Q)) pitch = pitchSpeed;
        if (Input.GetKey(KeyCode.E)) pitch = -pitchSpeed;

        rb.AddTorque(transform.right * pitch * Time.deltaTime, ForceMode.VelocityChange);
    }

    void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = targetPoint - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
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

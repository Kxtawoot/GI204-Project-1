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
    public float rotationSpeed = 5f;
    public float pitchSpeed = 10f;

    public int health = 100;

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

        if (Input.GetMouseButton(1))
        {
            TurnTowardsMouse();
        }

        PitchControl();
    }

    void TurnTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = worldMousePosition - transform.position;
        direction.z = 0;
        if (direction.sqrMagnitude > 0.1f)
        {
            float step = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }

    void PitchControl()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.left * pitchSpeed * Time.deltaTime);
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

    void OnCollisionEnter(Collision collision)
    {
        Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();
        if (meteorite != null)
        {
            TakeDamage(20);
        }
    }
}

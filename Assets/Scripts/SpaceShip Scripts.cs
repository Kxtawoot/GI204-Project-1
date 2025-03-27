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
    public float pitchSpeed = 2f; // ความเร็วในการหมุนขึ้นลง

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Movement Controls (WASD)
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

        // Apply drag to velocity and angular drag
        rb.velocity *= (1 - drag);
        rb.angularVelocity *= (1 - angularDrag);

        // Turn the spaceship towards the mouse if right-click is held
        if (Input.GetMouseButton(1)) // Right-click is held down
        {
            TurnTowardsMouse();
        }

        // Pitch control for up and down movement (Q/E)
        PitchControl();
    }

    void TurnTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Set distance from the camera to give 3D position
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate direction to the mouse
        Vector3 direction = worldMousePosition - transform.position;
        direction.z = 0; // Keep the rotation in the XY plane
        if (direction.sqrMagnitude > 0.1f)
        {
            // Slow down rotation
            float step = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }

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
    }
}

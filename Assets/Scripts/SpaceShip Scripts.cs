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
    }








=======
>>>>>>> parent of d74e474 (ใช้ Q เงยหน้า E กดหน้าลง)
}

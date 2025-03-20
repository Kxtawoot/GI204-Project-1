using UnityEngine;

public class SpaceShipScripts : MonoBehaviour
{
    private Rigidbody rb;
    public float engineThrust = 50;
    public float liftForce = 0.5f;
    public float drag = 0.03f;
    public float angularDrag = 0.03f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * engineThrust);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftForce);

        rb.linearVelocity -= rb.linearVelocity * drag;
        rb.angularVelocity -= rb.angularVelocity * angularDrag;
    }
}

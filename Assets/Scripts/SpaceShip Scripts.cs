using UnityEngine;

public class SpaceShipScripts : MonoBehaviour
{
    private Rigidbody rb;
    public float engineThrust = 50f;
    public float liftForce = 0.5f;
    public float drag = 0.03f;
    public float angularDrag = 0.03f;
    public float strafeThrust = 30f; // แรงขับด้านข้าง

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // กด Space เพื่อเร่งไปข้างหน้า
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * engineThrust);
        }

        // เพิ่มแรงยก (Lift)
        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftForce);

        // กด A เพื่อเคลื่อนที่ไปทางซ้าย
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * strafeThrust);
        }

        // กด D เพื่อเคลื่อนที่ไปทางขวา
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * strafeThrust);
        }

        // ใช้แรงเสียดทานเพื่อลดความเร็ว
        rb.velocity *= (1 - drag);
        rb.angularVelocity *= (1 - angularDrag);
    }
}

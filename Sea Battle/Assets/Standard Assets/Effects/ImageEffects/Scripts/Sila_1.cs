using UnityEngine;
using System.Collections;

public class Sila_1 : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float rt;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        rb.AddForce(-transform.forward * speed * move);

        float turn = Input.GetAxis("Horizontal");
        rb.AddTorque(transform.up * rt * turn);

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
            //rb.freezeRotation = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}

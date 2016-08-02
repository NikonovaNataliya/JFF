using UnityEngine;
using System.Collections;

public class primerForce : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float amount;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    public void OnMouseDown()
    {
        rb.AddForce(transform.forward * speed);

    }
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;

        rb.AddTorque(transform.up * h, ForceMode.Force);
        rb.AddTorque(transform.right * v, ForceMode.Force);
    }
}

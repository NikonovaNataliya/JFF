using UnityEngine;
using System.Collections;

public class CC : MonoBehaviour {

    private Rigidbody rb;
    private Transform tr;
    private Vector3 inp;
    private Vector3 vel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = transform;
    }

    void Update()
    {
        inp.x = Input.GetKey(KeyCode.A) ? -45f : 0f + (Input.GetKey(KeyCode.D) ? 45f : 0f);
        inp.y = 0f;
        inp.z = Input.GetKey(KeyCode.W) ? 10f : 0f + (Input.GetKey(KeyCode.S) ? -10f : 0f);
    }

    void FixedUpdate()  //ускорение и торможение
    {

        transform.rotation *= Quaternion.Euler(0f, inp.x * Time.deltaTime, 0f);
        vel = transform.InverseTransformDirection(rb.velocity);

        if (vel.sqrMagnitude > 0.001f)
            vel = Quaternion.Inverse(Quaternion.LookRotation(vel)) * vel * Mathf.Sign(vel.z);

        rb.velocity = transform.TransformDirection(vel + new Vector3(0f, inp.y * Time.deltaTime, inp.z * Time.deltaTime));
    }
}

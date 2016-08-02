using UnityEngine;
using System.Collections;

public class Sila_1 : MonoBehaviour {

    public float amount = 50f;	

	public void OnMouseDown() {

        GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Force);
        GetComponent<Rigidbody>().useGravity = true;    
    }

    public void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;

        GetComponent<Rigidbody>().AddTorque(transform.up * h, ForceMode.Force);
        GetComponent<Rigidbody>().AddTorque(transform.right * v, ForceMode.Force);
    }
}

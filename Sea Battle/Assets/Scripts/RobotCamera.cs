using UnityEngine;
using System.Collections;

public class RobotCamera : MonoBehaviour {

    Quaternion originRotation;
    float angleHorizontal;
    float angleVertical;
    public float mouseSens = 5f;
    public float stopFactor = 8f;

	void Start () {

        originRotation = transform.rotation;
	}
	
    void FixedUpdate()
    {
        angleHorizontal += Input.GetAxis("Mouse X") * mouseSens;
        angleVertical += Input.GetAxis("Mouse Y") * mouseSens;

        angleVertical = Mathf.Clamp(angleVertical, -10, 10);

        Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(angleVertical, Vector3.right);
        transform.rotation = originRotation * rotationY * rotationX;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += transform.forward / stopFactor;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward / stopFactor;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += transform.right / stopFactor;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= transform.right / stopFactor;
        //}
    }
}

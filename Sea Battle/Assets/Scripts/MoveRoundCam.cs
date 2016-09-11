using UnityEngine;
using System.Collections;

public class MoveRoundCam : MonoBehaviour {

    public Transform target;
   
    public float distance=1f ;
    public float maxDistance = 10.0f;
    public float minDistance = 0.5f;
    public float xSpeed = 500.0f;
    public float ySpeed = 250.0f;
    public float yminLimit = -10.0f;
    public float ymaxLimit = 80.0f;
    public float speedZoom = 20.0f;

    public float x;
    private float y;
    public Vector3 rot_cam;

    void Start() {

        Vector3 angles = transform.localEulerAngles;
        x = angles.y;
        y = angles.x;
        Cursor.lockState = CursorLockMode.Locked;   // Screen.lockCursor
    }

        void LateUpdate() {

        if (Input.GetAxis("Mouse X") !=0) {
            x += Input.GetAxis("Mouse X") * xSpeed;
            y -= Input.GetAxis("Mouse Y") * ySpeed;

            y = Mathf.Clamp(y, yminLimit, ymaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.localRotation = rotation;
            rot_cam = rotation.eulerAngles;
           // Vector3 rotationAngles = rotation.eulerAngles;   переменная для поворота робота
           // Debug.Log(rotationAngles);
             
            Vector3 position = /* target.position */  - (rotation * Vector3.forward * distance);
            transform.localPosition = position;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            Vector3 localPosition;
            distance = Vector3.Distance(transform.position, target.position);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * speedZoom,
                                   minDistance, maxDistance);
            localPosition = -(transform.forward * distance) + target.position;
            transform.position = localPosition;
        }
    }
}

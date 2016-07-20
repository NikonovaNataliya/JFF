using UnityEngine;
using System.Collections;

public class MoveRoundCam : MonoBehaviour {

    public Transform target;
   
    public float distance ;
    public float maxDistance = 10.0f;
    public float minDistance = 0.5f;
    public float xSpeed = 500.0f;
    public float ySpeed = 250.0f;
    public float yminLimit = -10.0f;
    public float ymaxLimit = 80.0f;
    public float speedZoom = 20.0f;

    private float x;
    private float y;


    void Start()
    {
        Vector3 angles = transform.localEulerAngles;
        x = angles.y;
        y = angles.x;
    }

        void LateUpdate()
    {

        if (!target)
            return;
        if (Input.GetMouseButton(2))
        {
            x += Input.GetAxis("Mouse X") * xSpeed;
            y -= Input.GetAxis("Mouse Y") * ySpeed;

            y = Mathf.Clamp(y, yminLimit, ymaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.localRotation = rotation;

            Vector3 position = /* target.position  */ - (rotation * Vector3.forward * distance);
            transform.localPosition = position;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 position;
            distance = Vector3.Distance(transform.position, target.position);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * speedZoom,
                                   minDistance, maxDistance);
            position = -(transform.forward * distance) + target.position;
            transform.position = position;
        }
    }
}

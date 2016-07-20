using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


     float xRotation;
     float yRotation;
     float speedRotation = 5.0f;

     float currentXrotation;
     float currentYrotation;
     float xRotationVelocity;
     float yRotationVelocity;

    //float TransX;
    //float TransZ;
    public float speedZoom = 50.0f;

    public bool zooming;
    public float binocul_speedZoon;

    void Update()
    {
        CameraRotation();
        CameraZoom();
        Binoculars();

    }

    void CameraRotation () {

        if (Input.GetMouseButton(0))
        {
            xRotation -= Input.GetAxis("Mouse Y") * speedRotation;
            yRotation += Input.GetAxis("Mouse X") * speedRotation;

            xRotation = Mathf.Clamp(xRotation, -25, 45);

            currentXrotation = Mathf.SmoothDamp(currentXrotation, xRotation, ref xRotationVelocity, 0.1f);
            currentYrotation = Mathf.SmoothDamp(currentYrotation, yRotation, ref yRotationVelocity, 0.1f);

            transform.localRotation = Quaternion.Euler(currentXrotation, currentYrotation, 0);
        }

    }

    void CameraZoom()
    {

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
           Camera.main.transform.Translate(Vector3.forward * speedZoom * Time.deltaTime);

        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            Camera.main.transform.Translate(Vector3.back * speedZoom * Time.deltaTime);
        }
    }

    void Binoculars()
    { 
        //if (zooming)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    float zoomDistance = binocul_speedZoon * Input.GetAxis("Vertical") * Time.deltaTime;
        //    Camera.main.transform.Translate(ray.direction * zoomDistance, Space.World);
        //}

    }
}

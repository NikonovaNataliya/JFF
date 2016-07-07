using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


     float xRotation;
     float yRotation;
     float speedRotation = 2f;

     float currentXrotation;
     float currentYrotation;
     float xRotationVelocity;
     float yRotationVelocity;

    float CamMax = 9f;
    float CamMin = 0f;

    float TransX;
    float TransZ;

    void Start()
    {
        Debug.Log("x :" + xRotation);
        Debug.Log("y :" + yRotation);
    }

    void Update()
    {
        CameraRotation();
        CameraZoom();
        CameraTranslater();
        Debug.Log("x :" + xRotation);
        Debug.Log("y :" + yRotation);
    }

    void CameraRotation () {

        if (Input.GetMouseButton(2))
        {
            xRotation -= Input.GetAxis("Mouse Y") * speedRotation;
            yRotation += Input.GetAxis("Mouse X") * speedRotation;

            xRotation = Mathf.Clamp(xRotation, -85, 85);

            currentXrotation = Mathf.SmoothDamp(currentXrotation, xRotation, ref yRotationVelocity, 0.1f);
            currentYrotation = Mathf.SmoothDamp(currentYrotation, yRotation, ref yRotationVelocity, 0.1f);

            Camera.main.transform.rotation = Quaternion.Euler(currentXrotation, currentYrotation, 0);
        }

    }

    void CameraZoom()
    {
        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && (Camera.main.transform.position.y < CamMax))
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
                                                  Camera.main.transform.position.y + 0.1f,
                                                  Camera.main.transform.position.z);
        }
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && (Camera.main.transform.position.y > CamMin))
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
                                                  Camera.main.transform.position.y - 0.1f,
                                                  Camera.main.transform.position.z);
        }
    }

    void CameraTranslater()
    {
        TransX = Input.GetAxis("Horizontal") * 1.5f * Time.deltaTime;
        TransZ = Input.GetAxis("Vertical") * 1.5f * Time.deltaTime;
        // прыгало тут!
        Camera.main.transform.Translate(TransX, 0, TransZ);
    }
}

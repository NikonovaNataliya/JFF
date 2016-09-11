using UnityEngine;
using System.Collections;

public class CameraFPCMove : MonoBehaviour {

    public float xmaxLimit = 80.0f;
    public float xminLimit = -80.0f;
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public float yminLimit = -10.0f;
    public float ymaxLimit = 50.0f;

    public float x;
    private float y;
    public Vector3 rotCamFPC;

    void Start () {
        Vector3 angles = transform.localEulerAngles;
        x = angles.y;
        y = angles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate() {
    
           // if (Input.GetAxis("Mouse X") != 0) {
                x += Input.GetAxis("Mouse X") ;
                y -= Input.GetAxis("Mouse Y") ;

                y = Mathf.Clamp(y, yminLimit, ymaxLimit);
                x = Mathf.Clamp(x, xminLimit, xmaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        transform.localRotation = rotation;
        // transform.localRotation = Quaternion.LookRotation(this.transform.localPosition, rotCamFPC);
        rotCamFPC = rotation.eulerAngles;

    }
}

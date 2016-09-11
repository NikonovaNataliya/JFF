using UnityEngine;
using System.Collections;

public class MoveRoundCamAlien : MonoBehaviour {

    Quaternion originRotation;
    float angleHorizontal;
    float angleVertical;
    public float mouseSens = 5.0f;
    public float speed = 8.0f;
    public Vector3 rot;
    public Quaternion rot_cam;
    // MoveAlien _moveAlien;
    // Vector3 tt;
    // Vector3 currentPositionCam;
    public Transform alien;
   // public const int dist_cam_al=2;
    public Vector3 Pos;

    void Start () {

        originRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;

       // _moveAlien = GameObject.Find("Lampa").GetComponent<MoveAlien>();
       // currentPositionCam = transform.position;
    }
	

	void FixedUpdate () {

        angleHorizontal += Input.GetAxis("Mouse X") * mouseSens;
        angleVertical += Input.GetAxis("Mouse Y") * mouseSens;

        angleVertical = Mathf.Clamp(angleVertical, -50f, 50f);

        Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(-angleVertical, Vector3.right);
        transform.rotation = originRotation * rotationY * rotationX;
        rot = rotationY.eulerAngles;
        rot_cam = rotationY;

        transform.position = alien.position + Pos;
        /*  if (Input.GetKey(KeyCode.W)) {
              transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * Time.deltaTime* speed;
          }
          if (Input.GetKey(KeyCode.S)) {
              transform.position -= new Vector3(transform.forward.x, 0, transform.forward.z) * Time.deltaTime* speed;
          }
          if (Input.GetKey(KeyCode.D)) {
              transform.position += transform.right * Time.deltaTime* speed;
          }
          if (Input.GetKey(KeyCode.A)) {
              transform.position -= transform.right * Time.deltaTime* speed;
          }*/
        // float dist = (alien.position - transform.position).sqrMagnitude;
        // if(dist > dist_cam_al) {

        // }
    }
}

using UnityEngine;
using System.Collections;

public class MoveManWithGan : MonoBehaviour {

    CharacterController controller;
    Animator anim;

    Vector3 direction;
    public float turnSpeed;
    public float speedMove;
    public float rot_horizontal;

    MoveRoundCam cam_switch;
    MoveRoundCam2 cam_switch2;
    //float rotationManWithGun;
    //public GameObject CameraFPC;
    //CameraFPCMove camMan;

    void Start () {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //  camMan = CameraFPC.GetComponent<CameraFPCMove>();
        cam_switch = GameObject.Find("CameraTPC").GetComponent<MoveRoundCam>();
       // cam_switch.enabled = true;
        cam_switch2 = GameObject.Find("CameraTPC").GetComponent<MoveRoundCam2>();

    }
	

	void FixedUpdate () {

         if (Input.GetMouseButtonDown(0)) {
         transform.rotation *= Quaternion.Euler(0, cam_switch.rot_cam.x, 0);
        //transform.rotation *= cam_switch.rot_cam;
          }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (vertical == 0 ) {
            cam_switch.enabled = true;
            cam_switch2.enabled = false;
        }
        else if(vertical != 0){
            cam_switch.enabled = false;
            cam_switch2.enabled = true;
            rot_horizontal += Input.GetAxis("Mouse X") * turnSpeed;
            transform.rotation = Quaternion.Euler(0, rot_horizontal, 0);
        }

       // if (horizontal != 0 && vertical != 0) {
            direction = new Vector3(horizontal, 0, vertical);
            direction = transform.TransformDirection(direction);
            controller.Move(direction * speedMove * Time.deltaTime);
       // }

       // transform.rotation = Quaternion.Euler(0, cam_switch.x, 0);







        if (vertical != 0) {
            anim.SetBool("Idle-Walk", true);
        }
        if (vertical == 0) {
            anim.SetBool("Idle-Walk", false);
            //anim.SetBool("Idle-WalkOver", false);
        }
        if (horizontal > 0 && horizontal <= 1.0f) {
            anim.SetBool("Idle-Right", true);
        }
        if (horizontal < 0 && horizontal >= -1.0f) {
            anim.SetBool("Idle-Left", true);
        }
        if(horizontal == 0) {
            anim.SetBool("Idle-Right", false);
            anim.SetBool("Idle-Left", false);
        }


       

       
    }
}

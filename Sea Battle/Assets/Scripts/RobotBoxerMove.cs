using UnityEngine;
using System.Collections;

public class RobotBoxerMove : MonoBehaviour {

    CharacterController controller;
    Animator anim;
    public Transform cameraTransform;

    //  int boxHash = Animator.StringToHash("2jab2");
    //  int boxHash2 = Animator.StringToHash("jabLeft");
    //int boxStateHash = Animator.StringToHash("Base Layer.Stance");

    public float speed;
    public float turnSpeed;

    private float lastClickTime;

    void Start () {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
 
    }


    void Update() {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = transform.TransformDirection(direction);

        controller.Move(direction * Time.deltaTime);

        if (vertical > 0 && vertical < 1.0f) {
            anim.SetBool("Idle-Walk", true);
            anim.SetBool("Idle-WalkOver", false);
        }
        if (vertical < 0 && vertical >= -1) {
            anim.SetBool("Idle-WalkOver", true);
            anim.SetBool("Idle-Walk", false);
        }
        if (vertical == 0) {
            anim.SetBool("Idle-Walk", false);
            anim.SetBool("Idle-WalkOver", false);
        }

        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.W)) {
            controller.Move(direction * speed * Time.deltaTime);
            anim.SetBool("Walk-Run 0", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
            anim.SetBool("Walk-Run 0", false);


         if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") <= 1.0f)
            transform.Rotate(0.0f, Input.GetAxis("Vertical") * turnSpeed, 0.0f, Space.Self);

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Horizontal") >= -1.0f) {
            transform.Rotate(0.0f, -Input.GetAxis("Vertical") * turnSpeed, 0.0f, Space.Self);
        }


        if (Input.GetKey(KeyCode.Space)) {
           // tr = new Vector3(0, tr.y, 0);
            //transform.forward = tr;

            // Quaternion cam0 = Quaternion.LookRotation(cameraTransform.transform.forward*Time.deltaTime);
            // this.transform.localRotation = cam0;
           // tr = transform.forward;

        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            anim.SetBool("Idle-Stance", true);
           // anim.SetTrigger(boxHash2);
            //anim.SetTrigger(boxHash);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            anim.SetBool("Idle-Stance", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            anim.Play("Block", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            anim.Play("Uppercut", -1, 0);
        }

        if (Input.GetMouseButtonDown(0)) {

            if (Time.time - lastClickTime < 0.25f) {
                anim.Play("2jab2", -1, 0);
            }
            else {
            anim.Play("jabLeft", -1, 0f);
            }
            lastClickTime = Time.time;
        }

        if (Input.GetMouseButtonDown(1)) {
            anim.Play("jabRight", -1, 0f);
        }

        //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //if (Input.GetKeyDown(KeyCode.D) && stateInfo.fullPathHash == boxStateHash) {
        //    anim.SetTrigger(boxHash);
        //}
    }
}

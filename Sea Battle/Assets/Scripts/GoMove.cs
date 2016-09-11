using UnityEngine;
using System.Collections;

public class GoMove : MonoBehaviour {

    Animator anim;
    CharacterController controller;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float graviti = 20.0f;
    public float turnSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Start() {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update() {

        moveDirection = new Vector3(Input.GetAxis("Horizontal")*2.0f, 0, Input.GetAxis("Vertical")*3.0f);
        moveDirection = -transform.TransformDirection(moveDirection) * speed;

        if (Input.GetButton("Jump"))
            moveDirection.y = jumpSpeed;

        moveDirection.y -= graviti * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0.0f, -Input.GetAxis("Vertical") * turnSpeed, 0.0f, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0.0f, Input.GetAxis("Vertical") * turnSpeed, 0.0f, Space.Self);
        }

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") <= 1) {
            anim.SetBool("Idle-Walk", true);
            anim.SetBool("Idle-WalkOver", false);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") >= -1) {
            anim.SetBool("Idle-WalkOver", true);
            anim.SetBool("Idle-Walk", false);
        }
        if (Input.GetAxis("Vertical") == 0) {
            anim.SetBool("Idle-Walk", false);
            anim.SetBool("Idle-WalkOver", false);
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") <= 1) {
            anim.SetBool("Idle-TurnLeft", false);
            anim.SetBool("Idle-TurnRight", true);
        }
        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Horizontal") >= -1) {
            anim.SetBool("Idle-TurnRight", false);
            anim.SetBool("Idle-TurnLeft", true);
        }
        if (Input.GetAxis("Horizontal") == 0) {
            anim.SetBool("Idle-TurnLeft", false);
            anim.SetBool("Idle-TurnRight", false);
        }  
    }
}

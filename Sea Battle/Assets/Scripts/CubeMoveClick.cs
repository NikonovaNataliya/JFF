using UnityEngine;
using System.Collections;

public class CubeMoveClick : MonoBehaviour {

    CharacterController controller;
    Animator anim;
    public float rotationSpeed;
    public float moveSpeed;
    public float gravity;
    RaycastHit hit;
    Ray ray;
    Vector3 target;
    Vector3 lastTarget = new Vector3();
    Vector3 dir;

	void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}	

	void Update () {

        if (Input.GetMouseButtonDown(1)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f)) {
                target = hit.point;
            }

            dir = target - transform.position;
            dir = new Vector3(dir.x, 0, dir.z);
            dir.Normalize();

            Quaternion look = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * rotationSpeed);

        }
        dir.y -= gravity * Time.deltaTime;

        float target_x =(int)target.x;
        float lastTarget_x = (int)lastTarget.x;
        float target_z = (int)target.z;
        float lastTarget_z = (int)lastTarget.z;

        if ((target_x != lastTarget_x) || (target_z != lastTarget_z)) {
            controller.Move(dir * Time.deltaTime * moveSpeed);
            lastTarget = new Vector3(transform.position.x, 0, transform.position.z);
            anim.SetBool("Idle-Walk", true);
        }
        else
            anim.SetBool("Idle-Walk", false);
    }
}

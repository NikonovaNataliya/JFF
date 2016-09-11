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

    private Quaternion m_currentTargetRotation = Quaternion.identity;
    private float m_closeEnough = 0.1f;
    private Plane myPlane;
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       this.myPlane = new Plane( Vector3.up, Vector3.zero );
	}	

	void Update () {

        if (Input.GetMouseButtonDown(1)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            float distance;
            if( this.myPlane.Raycast( ray, out distance ) ) {
                target = ray.GetPoint( distance );
            }
            // if (Physics.Raycast(ray, out hit, 1000.0f)) {
            //     target = hit.point;
            // }

            dir = target - transform.position;
            dir = new Vector3(dir.x, 0, dir.z);
            dir.Normalize();

           m_currentTargetRotation = Quaternion.LookRotation(dir);

        }
        float angle = Quaternion.Angle(transform.rotation, m_currentTargetRotation);
        if( Mathf.Abs( angle ) > 0.1f ) {
            transform.rotation = Quaternion.Slerp(transform.rotation, m_currentTargetRotation, Time.deltaTime * rotationSpeed);
        }
        dir.y -= gravity * Time.deltaTime;

        // float target_x =(int)target.x;
        // float lastTarget_x = (int)lastTarget.x;
        // float target_z = (int)target.z;
        // float lastTarget_z = (int)lastTarget.z;

        if( Vector3.Distance( target, lastTarget ) > m_closeEnough ) { // }   (target_x != lastTarget_x) || (target_z != lastTarget_z)) {
            controller.Move(dir * Time.deltaTime * moveSpeed);
            lastTarget = new Vector3(transform.position.x, 0, transform.position.z);
            anim.SetBool("Idle-Walk", true);
        }
        else
            anim.SetBool("Idle-Walk", false);
    }
}

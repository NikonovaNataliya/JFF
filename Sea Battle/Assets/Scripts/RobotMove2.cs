using UnityEngine;
using System.Collections;

public class RobotMove2 : MonoBehaviour {

    public GameObject target;
    public float targetDistance;
    public float speed;

    Animator anim;
    CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

	void Update () {

        Vector3 lookPosition = new Vector3(target.transform.position.x, this.transform.position.y, 
                                           target.transform.position.z);
        transform.LookAt(lookPosition);

        Vector3 previousPosition = transform.position;
        //Vector3 currentPosition;

        Vector3 direction = (target.transform.position - transform.position) / (target.transform.position - transform.position).magnitude;

        if(Vector3.Distance(transform.position, target.transform.position)>targetDistance) {
            transform.position += direction * Time.deltaTime * speed;
            direction = transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
        }

        Vector3 currentPosition = transform.position;
       // Debug.Log("2: " + currentPosition);

        if(previousPosition == currentPosition) {
            anim.SetBool("peace-walking", false);
        }
        if (previousPosition != currentPosition) {
            anim.SetBool("peace-walking", true);
        }
    }
}

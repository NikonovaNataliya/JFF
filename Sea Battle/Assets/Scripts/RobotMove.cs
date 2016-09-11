using UnityEngine;
using System.Collections;

public class RobotMove : MonoBehaviour {

    public float stopFactor;
    public float angleHorizontal;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update () {

        if (Input.GetKey(KeyCode.S)) // назад
        {
            transform.position += transform.forward / stopFactor;
            anim.SetBool("Idle-WalkOver", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
                    anim.SetBool("Idle-WalkOver", false);


        if (Input.GetKey(KeyCode.W)) //  вперед
        {
            transform.position -= transform.forward / stopFactor;
            anim.SetBool("Idle-Walk", true);
        }

        if (Input.GetKey(KeyCode.A))  // налево
        {
            // transform.position += transform.right / stopFactor;
            Quaternion rotationX = Quaternion.AngleAxis(angleHorizontal, -Vector3.up);
            transform.rotation *= rotationX;
            anim.SetBool("Idle-Turn", true);
        }


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) //|| (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("Idle-Walk", true);
            anim.SetBool("Idle-Turn", false);
        }
        //if (Input.GetKeyUp(KeyCode.W))
        //    anim.SetBool("Idle-Walk", false);

        if (Input.GetKey(KeyCode.A))  // налево
        {
           // transform.position += transform.right / stopFactor;
            Quaternion rotationX = Quaternion.AngleAxis(angleHorizontal, -Vector3.up);
            transform.rotation *= rotationX;
            anim.SetBool("Idle-Turn", true);
        }
        //if (Input.GetKeyUp(KeyCode.A))
        //    anim.SetBool("Idle-Turn", false);


        if (Input.GetKey(KeyCode.D))      // направо
        {
            //  transform.position -= transform.right / stopFactor;
            Quaternion rotationX = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
            transform.rotation *= rotationX;
            anim.SetBool("Idle-Turn", true);
        }
                if (Input.GetKeyUp(KeyCode.D))
                anim.SetBool("Idle-Turn", false);
    }
}

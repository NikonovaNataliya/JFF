using UnityEngine;
using System.Collections;

public class RobotMove2 : MonoBehaviour {

    public float speed;
    public float rotationSpeed;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void Update () {

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate( 0, 0, -translation);


        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        if (!Input.anyKey)
        {
            anim.SetBool("Idle-Walk", false);
            anim.SetBool("Idle-WalkOver", false);
            anim.SetBool("Idle-Turn", false);
        }
        if (translation > 0 && translation <= 1)
        {
            anim.SetBool("Idle-Walk", true);
            anim.SetBool("Idle-WalkOver", false);
        }
        if (translation < 0 && translation >=-1)
        {
            anim.SetBool("Idle-WalkOver", true);
            anim.SetBool("Idle-Walk", false);
        }
          if((rotation > 0 && rotation <= 1) || (rotation<0 && rotation>=-1))
        {
            anim.SetBool("Idle-Turn", true);
        }
	}
}

using UnityEngine;
using System.Collections;

public class RobotAnimat : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update () {

        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);
	}
}

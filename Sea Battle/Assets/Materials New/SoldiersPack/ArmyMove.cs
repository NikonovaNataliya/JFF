using UnityEngine;
using System.Collections;

public class ArmyMove : MonoBehaviour {

    CharacterController controller;
   // Animator anim;

    public float speed;

	void Start () {
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }
	

	void Update () {
        Vector3 start = Vector3.forward*Time.deltaTime;
        controller.Move(start * speed);
	}
}

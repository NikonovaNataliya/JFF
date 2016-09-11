using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

    CharacterController controller;
    public float speedMove;
    public float speedTurn;
    public float gravity;
    private float rot_horizontal;

    private Vector3 direction = Vector3.zero;

	void Start () {

        controller = GetComponent<CharacterController>();
	}
	

	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        direction *= speedMove;
        direction.y -= gravity * Time.deltaTime; 
        controller.Move(direction * Time.deltaTime);

        rot_horizontal += Input.GetAxis("Mouse X") * speedTurn;
        transform.rotation = Quaternion.Euler(0, rot_horizontal, 0);
	}
}

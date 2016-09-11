using UnityEngine;
using System.Collections;

public class MoveAlien : MonoBehaviour {

    CharacterController controller;
    Vector3 rotationAlien;
 
    MoveRoundCamAlien camAlien;
    public Vector3 currentPositionAlien;
   // private Quaternion currentRotationAlien;

    void Start () {

        controller = GetComponent<CharacterController>();
        camAlien = Camera.main.GetComponent<MoveRoundCamAlien>();

        // GameObject.Find("MainCamera").GetComponent<MoveRoundCamAlien>().rot = rotationAlien;
    }

    void FixedUpdate() { 

         float horizontal = Input.GetAxis("Horizontal");
         float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        controller.Move(direction * Time.deltaTime);

        currentPositionAlien = transform.position;
        Debug.Log(currentPositionAlien);

        transform.rotation *= camAlien.rot_cam;

        if (Input.GetMouseButtonDown(0)) {
            rotationAlien = camAlien.rot;
            transform.rotation = Quaternion.Euler(rotationAlien);
        } 
    }
}

using UnityEngine;
using System.Collections;

public class CameraFPSMove : MonoBehaviour {


//	void Start () {
	
//	}
	

	void FixedUpdate () {

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        vertical = Mathf.Clamp(vertical, 30, 30);


	}
}

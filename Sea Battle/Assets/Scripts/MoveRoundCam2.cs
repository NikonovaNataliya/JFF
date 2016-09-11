using UnityEngine;
using System.Collections;

public class MoveRoundCam2 : MonoBehaviour {

    public Transform target;

    void Start () {

	}
	
	void LateUpdate () {

        transform.localPosition = new Vector3(0, 0, -2);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

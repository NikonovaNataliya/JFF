using UnityEngine;
using System.Collections;

public class CameraControllerFirst : MonoBehaviour {

    public GameObject ShipRoot;
    private Vector3 offset;

	void Start () {

        offset = transform.position - ShipRoot.transform.position;
    }

    void LateUpdate () {
 
        transform.position = ShipRoot.transform.position + offset;
	}
}

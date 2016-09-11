using UnityEngine;
using System.Collections;

public class CamerasSwitch : MonoBehaviour {

    public Camera cam_FPC;
    public Camera cam_TPC;

	void Start () {

        cam_FPC.enabled = false;
        cam_TPC.enabled = true;
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            cam_FPC.enabled =! cam_FPC.enabled;
            cam_TPC.enabled = !cam_TPC.enabled;
        }
	}
}

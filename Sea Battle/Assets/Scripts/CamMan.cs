using UnityEngine;
using System.Collections;

public class CamMan : MonoBehaviour {

    public Camera camera_robot;
    public Camera camera_panorama;

	void Start () {

        camera_robot.enabled = true;
        camera_panorama.enabled = false;
	}
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            camera_robot.enabled =! camera_robot.enabled;
            camera_panorama.enabled = !camera_panorama.enabled;
        }
	}
}

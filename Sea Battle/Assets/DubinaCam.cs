using UnityEngine;
using System.Collections;

public class DubinaCam : MonoBehaviour {

    public Transform player;
    Vector3 startPositionCam;
    Vector3 startPositionPlayer;
    Vector3 dist;

    void Start () {
        startPositionCam = new Vector3(transform.position.x, 0, transform.position.z);
        startPositionPlayer = player.position;
        dist = startPositionCam - startPositionPlayer;
    }
	
	void Update () {

        transform.position = new Vector3(player.position.x,20,player.position.z) + dist;

	}
}

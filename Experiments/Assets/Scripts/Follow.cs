using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    // public Transform myTransform;
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        // Transform cam = GetComponent<Transform>();
        //        Debug.Log(cam);
        offset = transform.position - player.transform.position;
    }

	//void Update () {

 //       transform.LookAt(myTransform);
	//}
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

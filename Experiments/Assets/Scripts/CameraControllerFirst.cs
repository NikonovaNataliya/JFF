using UnityEngine;
using System.Collections;

public class CameraControllerFirst : MonoBehaviour {

    //   public GameObject ShipRoot;
    //   private Vector3 offset;

    //void Start () {

    //       offset = transform.position - ShipRoot.transform.position;
    //   }

    //   void LateUpdate () {

    //       transform.position = ShipRoot.transform.position + offset;
    //}

    float speed = 2f;
    float zoomSpeed = 2f;

    //public float minX = -360f;
    //public float maxX = 360f;

    public float minY = -45f;
    public float maxY = 45f;

    public float sensX = 100f;
    public float sensY = 100f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
 
}

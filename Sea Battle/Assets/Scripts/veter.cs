using UnityEngine;
using System.Collections;

public class veter : MonoBehaviour {

    public float waterLevel, floatHeight;
    public Vector3 buoyancyCenterOffset;
    public float bounceDamp;

    void FixedUpdate () {           //ПЛАВУЧЕСТЬ

        Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
        float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
        if (forceFactor > 0f)
        {
            Vector3 uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp);
            GetComponent<Rigidbody>().AddForceAtPosition(uplift,actionPoint);
        }        
  }

}

using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    public float stopStart = 1.5f, speed = 5f, rotationSpees = 100f, heightPlayer = 1f;

    private float mag;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 dir;
    private Vector3 target = new Vector3();
    private Vector3 lastTarget = new Vector3();
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1)) {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 10000.0f)) {

                target = hit.point;
            }
        }
        float possibleRotation = MoveTo();
        LookAtThis( 1.0f );
	}

    private float CalculateAngle(Vector3 temp) {

        dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
        return Vector3.Angle(dir, transform.forward);

    }

    private void LookAtThis( float possibleRotation )
    {
        if (target != lastTarget)
        {

            float angleToTarget = CalculateAngle(target);
            Debug.Log("angleToTarget : " + angleToTarget);
            if (angleToTarget > 3)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(dir), possibleRotation * rotationSpees * Time.deltaTime);
            }
        }
    }

    private float MoveTo() {

        if (target == lastTarget)
        {
            lastTarget = target;
            return 0;
        }
        mag = (transform.position - target).magnitude;
        Vector3 oldPosition = transform.position;
        Vector3 mathPosition = Vector3.MoveTowards(transform.position, target, mag >
            stopStart ? speed * UnityEngine.Time.deltaTime : Mathf.Lerp(speed * 0.5f, speed, mag / stopStart)
            * UnityEngine.Time.deltaTime);

        Vector3 deltaPosition = mathPosition - oldPosition;
        Vector3 projectDeltaPosition = Vector3.Project(deltaPosition, transform.forward);

        Vector3 projectDeltaPositionInLocal = transform.InverseTransformDirection(projectDeltaPosition);
        if( projectDeltaPositionInLocal.z < 0 )
        {
            return 0;
        }

        transform.position = oldPosition + projectDeltaPosition;

        ray = new Ray(transform.position, Vector3.up * (-1) );
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + heightPlayer, transform.position.z);
        }
        return Vector3.Distance( oldPosition, transform.position );
    }
}

using UnityEngine;
using System.Collections;

public class MovePlayerFirst : MonoBehaviour {

    public GameObject player;
    public float stopStart = 1.5f, speed = 5f, rotationSpeed = 100f, heightPlayer = 1f;

    float mag, angelToTarget;
    Ray ray;
    RaycastHit hit;
    Vector3 dir;
    Vector3 target = new Vector3();
    Vector3 lastTarget = new Vector3();

    Animator m_Animator;

	void Update () {

        if (Input.GetMouseButton(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                target = hit.point;
            }
        }
        LookAtThis();
        MoveTo();
	}

    private void CalculateAngel(Vector3 temp)
    {
        dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
        if( Vector3.Distance( dir, Vector3.zero ) < 25.0f ) {
            angelToTarget = 0f;
            return;
        }
        angelToTarget = Vector3.Angle(dir, transform.forward);
    }

    private void LookAtThis()
    {
        if (target != lastTarget)
        {
            CalculateAngel(target);
            if (angelToTarget > 3.0f)
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                             Quaternion.LookRotation(dir),
                                                             rotationSpeed * UnityEngine.Time.deltaTime);
        }
    }

    private void MoveTo()
    {
        if (target != lastTarget)
        {
            mag = (transform.position - target).magnitude;
            transform.position = Vector3.MoveTowards(transform.position, target, mag >
    stopStart ? speed * UnityEngine.Time.deltaTime : Mathf.Lerp(speed * 0.5f, speed, mag / stopStart) *
                               UnityEngine.Time.deltaTime);
            ray = new Ray(transform.position, -Vector3.up);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + heightPlayer, transform.position.z);
            }
        }
        else
            lastTarget = target;
    }
}

using UnityEngine;
using System.Collections;

public class CamRayDubina : MonoBehaviour {

    public Transform target;
    public DubinaMove player;
    private Vector3 direction;
    RaycastHit hit;


    void Update() {
        if (Input.GetMouseButtonUp(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f)) {
                target.position = hit.point;
                player.GetTarget(target.position);
            }
        }
    }
}

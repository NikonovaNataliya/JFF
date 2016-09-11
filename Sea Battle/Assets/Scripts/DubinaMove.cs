using UnityEngine;
using System.Collections;

public class DubinaMove : MonoBehaviour {

    CharacterController player;

    public float radiusNoClick = 1f;
    public Vector3 target;
    Vector3 direction;
    public float speedRotation = 10f;
    public float speedMove = 45f;
    private bool onPlace = true;

	void Start () {

        player = GetComponent<CharacterController>();
	}
	

	void Update () {
        if (!onPlace) {
            direction = target -transform.position;
            direction = new Vector3(transform.position.x, 0, transform.position.z);
            direction.Normalize();

            Quaternion look = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * speedRotation);
            player.Move(direction * Time.deltaTime * speedMove);
        }
     
    }
    public void GetTarget(Vector3 target) {
                if ((Mathf.Abs(transform.position.x - target.x) >= radiusNoClick &&
                     Mathf.Abs(transform.position.z - target.z) >= radiusNoClick)) {
                    this.target = target;
                    onPlace = false;
        }
    }
    public void OnPlaceTrue() {
        onPlace = true;
    }
}

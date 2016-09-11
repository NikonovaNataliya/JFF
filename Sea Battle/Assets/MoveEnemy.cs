using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

    public Transform player;
    public float speedRot;
    public float speedMove;

    Animator anim;

    void Start () {

        anim = GetComponent<Animator>();
    }
	
	void Update () {

	}
    void OnTriggerStay(Collider player) {
        Vector3 dir = this.player.position - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        dir.Normalize();

        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(dir),speedRot);
        transform.Translate(Vector3.forward *speedMove * Time.deltaTime);
        Vector3 currentPosition = transform.position;
        anim.SetBool("Idle-Walk", true); 

    }
    void OnTriggerExit(Collider player) {
        anim.SetBool("Idle-Walk", false);
    }
}

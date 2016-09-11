using UnityEngine;
using System.Collections;

public class TriggerOnTarget : MonoBehaviour {

    public DubinaMove player;
	
	void OnTriggerEnter(Collider onPlace) {

        player.OnPlaceTrue();
	}
}

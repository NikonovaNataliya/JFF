using UnityEngine;
using System.Collections;

public class TriggerOnTarget : MonoBehaviour {

    public ShipController player;

    void OnTriggerEnter(Collider onPlace) { 
    
        player.OnPlaceTrue();
    }
}

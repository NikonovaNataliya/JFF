using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {


    //void Updata()
    //{
    //    float currentTime = Time.realtimeSinceStartup;

    //    GameObject ship = this.gameObject;
    //    Transform shiptransform = ship.GetComponent<Transform>();
    //    Vector3 place = new Vector3(140, 4, 200);
    //    place.x = Mathf.Sin(currentTime) ;
    //    place.y = 0.0f;
    //    place.z = Mathf.Cos(currentTime);

    //   shiptransform.localPosition = place;
    //    Debug.Log(place);
    //}
    ShipController player;
    public float radiusNoClick = 0.06f;
    public Vector3 target = Vector3.zero;
    private Vector3 direction;
    public float speedRotation = 10.0f;
    public float speedMove = 45.0f;
    private bool onPlace = true;
    private CharacterState _characterState;

    enum CharacterState {
        Idle = 0,
        Walking = 1,
    }

    void Start() {

        player = (ShipController)gameObject.GetComponent(typeof(ShipController));
    }

    void Update() { 
    
        if (!onPlace) { 
        
            direction = target - this.transform.position;
            direction = new Vector3(direction.x, 4, direction.z);
            direction.Normalize();

            Quaternion look = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime * speedRotation);
            player.Move(direction* Time.deltaTime * speedMove);

            _characterState = CharacterState.Walking;
        }
        else
            _characterState = CharacterState.Idle;
    }

    public void Move(Vector3 direction) { 
    

    }
    public void GetTarget(Vector3 target) { 
    
        if (Mathf.Abs(transform.position.x - target.x) >= radiusNoClick &&
                Mathf.Abs(transform.position.z - target.z) >= radiusNoClick) { 
        
            this.target = target;
            onPlace = false;
        }
    }
    public void OnPlaceTrue() { 
    
        onPlace = true;
    }
}

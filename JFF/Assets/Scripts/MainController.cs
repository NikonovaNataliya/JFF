using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainController : MonoBehaviour {

	public Vector3 m_startPosition;

	// Use this for initialization
	void Start () {
		GameObject centerRotation = GameObject.CreatePrimitive( PrimitiveType.Cube );
		Transform centerRotationTransform = centerRotation.GetComponent<Transform>();
		centerRotationTransform.localPosition = m_startPosition;
	}
	
	// Update is called once per frame
	void Update () {


		// int a = 5;
		// float c = 6.0f;
		// if( typeOf( a ) == typeOf( float ) ) {

		// }

		float currentTime = Time.realtimeSinceStartup;

		GameObject myGameObject = this.gameObject;
		Transform myTransform = myGameObject.GetComponent<Transform>();
		Vector3 currentPosition = new Vector3( 0, 0, 0 );
		currentPosition.x = Mathf.Sin( currentTime );
		currentPosition.y = Mathf.Cos( currentTime );
		currentPosition.z = 0.0f;
		currentPosition = currentPosition + m_startPosition;
		myTransform.localPosition = currentPosition;
	}
}
// struct Vector3 {
// 	public float x;
// 	public float y;
// 	public float z;
// }

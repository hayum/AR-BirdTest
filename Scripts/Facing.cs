using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {
	//Rigidbody rb;
	//public Transform fore;
	//public Transform target;
	Vector3 prevPosition;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		prevPosition=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//if (rb.velocity != Vector3.zero)
		//transform.rotation = Quaternion.LookRotation(fore.position);
		//transform.forward =rb.velocity;
		Vector3 deltaPosition = transform.position - prevPosition;
		//transform.LookAt(target);

		if (deltaPosition != Vector3.zero) {
			// Same effect as rotating with quaternions, but simpler to read
			transform.forward = deltaPosition*Time.deltaTime * 100;

		}
		// Recording current position as previous position for next frame
		prevPosition = transform.position;
	}
}

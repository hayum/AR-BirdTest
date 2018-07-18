using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		eulerAngles = new Vector3(0, 90, 0);
		transform.rotation = Quaternion. Euler(eulerAngles);
	}
}

using UnityEngine;
using System.Collections;

public class FixTangent : MonoBehaviour {

    Vector3 _previousPos;
    Vector3 _lastPos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
        transform.localRotation = Quaternion.LookRotation( _lastPos - _previousPos );

        _previousPos = _lastPos;
        _lastPos = transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNRise : MonoBehaviour {
	public Transform manPosition;
	public Transform endPoint;
	public Transform startPoint;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isFound.fly){
			transform.RotateAround(manPosition.position, Vector3.forward, 50 * Time.deltaTime);
			//Vector3.Distance(transform.position,endPoint.position)
			Debug.Log(Vector3.Distance(transform.position,endPoint.position));
			if(Vector3.Distance(transform.position,endPoint.position)>30.0f){
				transform.Translate(Vector3.up * Time.deltaTime*5);
			}
			else{
			//gameObject.SetActive(false);
				transform.position=startPoint.position;
				Vector3 eulerAngles = startPoint.rotation.eulerAngles;
				transform.rotation = Quaternion. Euler(eulerAngles);
			}
		}
	}



}

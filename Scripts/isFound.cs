﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class isFound : MonoBehaviour, ITrackableEventHandler  {
	private TrackableBehaviour mTrackableBehaviour;
	static public bool fly;
	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
			fly = true;
		}
		else
		{
			fly = false;
		}
	}
}

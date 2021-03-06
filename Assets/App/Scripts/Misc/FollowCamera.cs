﻿using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 5.0f;
	// the height we want the camera to be above the target
	public float height = 15.0f;
	// How much we 
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	
	public float moveInZ = 8.0f;
	private float flag_moveInZ = 0.0f;
	
	// Place the script in the Camera-Control group in the component menu
	[AddComponentMenu("Camera-Control/Follow Camera")]

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Early out if we don't have a target
		if (!target) return;
		Vector3 localTarget = target.position;

		if(Input.GetButtonDown("Fire2")){
			flag_moveInZ = 1.0f;
		}
		if (Input.GetButtonUp ("Fire2")) {
			flag_moveInZ = 0.0f;
		}
		if (flag_moveInZ > 0.0f) {
			flag_moveInZ+=4.0f*Time.deltaTime;
			flag_moveInZ = Mathf.Clamp(flag_moveInZ,0,moveInZ);
		}
		localTarget.z += flag_moveInZ;

		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = localTarget;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);

	}
}

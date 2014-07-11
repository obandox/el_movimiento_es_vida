using UnityEngine;
using System.Collections;

public class PushRigidbody : MonoBehaviour {
	public float pushPower = 10.0f;
	public float weight = 6.0f;
	public float gravity = 9.8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {

		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic)
			return;	

		Vector3 force;

		
		// We use gravity and weight to push things down, we use
		// our velocity and push power to push things other directions
		if (hit.moveDirection.y < -0.3f) {
			force = new Vector3 (0, -0.5f, 0) * gravity * weight;
		} else {
			force = hit.controller.velocity * pushPower;
		}
		
		// Apply the push
		body.AddForceAtPosition(force, hit.point);
	}
}

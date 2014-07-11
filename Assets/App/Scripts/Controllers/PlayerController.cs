using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speedFowardPerSec  = 5; // units per second
	public float speedBackwardPerSec  = 2; // units per second
	public float jumpSpeed = 8;
	public float gravity = 9.8f;
	private float vSpeed = 0; // current vertical velocity
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 vel;
		if (Input.GetAxis ("Vertical") > 0)
				vel = new Vector3 (Input.GetAxis ("Horizontal") * speedFowardPerSec / 2, 0, Input.GetAxis ("Vertical") * speedFowardPerSec);
		else
			    vel = new Vector3 (Input.GetAxis ("Horizontal") * speedFowardPerSec / 2, 0, Input.GetAxis ("Vertical") * speedBackwardPerSec);


		var controller = GetComponent<CharacterController>();
		if (controller.isGrounded){
		    vSpeed = 0; // grounded character has vSpeed = 0...
		    if (Input.GetKeyDown("space")){ // unless it jumps:
		    	vSpeed = jumpSpeed;
		    }
		}
	  // apply gravity acceleration to vertical speed:
	  vSpeed -= gravity * Time.deltaTime;
	  vel.y = vSpeed; // include vertical speed in vel
	  // convert vel to displacement and Move the character:
	  controller.Move(vel * Time.deltaTime);
	}
}

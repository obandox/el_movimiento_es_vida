using UnityEngine;
using System.Collections;

public class HelperPlane : MonoBehaviour {

	// Use this for initialization

	private MeshRenderer myRenderer;

	void Start () {
		myRenderer = gameObject.GetComponent<MeshRenderer>();
		myRenderer.enabled = false;

	}
	
	public void OnTriggerEnter(Collider Colli){

		if(Colli.gameObject.tag == "Player"){
			myRenderer.enabled = true;
		}
	}

	public void OnTriggerExit(Collider Colli){
		if(Colli.gameObject.tag == "Player"){
			myRenderer.enabled = false;
			Destroy(gameObject,3);
		}
	}
}
